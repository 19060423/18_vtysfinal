CREATE DATABASE projeler;
USE projeler;

-- -----------------------------------------------------
-- TABLOLAR START
-- -----------------------------------------------------

CREATE TABLE proje (
	projeId INT AUTO_INCREMENT PRIMARY KEY,
	projeAd VARCHAR(20) NULL DEFAULT NULL,
	projeDurum ENUM('Başlanılmadı', 'Aktif', 'Tamamlandı') NULL DEFAULT NULL,
	baslangicTarihi DATE NOT NULL,
	bitisTarihi DATE NOT NULL
);

CREATE TABLE çalışan (
  calisanId  INT AUTO_INCREMENT PRIMARY KEY,
  ad VARCHAR(20) NULL DEFAULT NULL,
  soyad VARCHAR(20) NULL DEFAULT NULL,
  iseAlinmaTarihi DATE NULL
);

CREATE TABLE görev (
	projeId INT,
	calisanId  INT,
	gorevId  INT,
	PRIMARY KEY (projeId, calisanId, gorevId),
	gorevAd VARCHAR(40) NULL DEFAULT NULL,
	gorevDurum ENUM('Başlanılmadı', 'Aktif', 'Tamamlandı') NULL DEFAULT NULL,
	baslangicTarihi DATE NOT NULL,
	bitisTarihi DATE NOT NULL,
	FOREIGN KEY (projeId)
	REFERENCES proje (projeId)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (calisanId)
	REFERENCES çalışan(calisanId)
	ON DELETE CASCADE
);

CREATE TABLE görevdelay (
	projeId INT,
	calisanId INT,
	gorevId INT,
	delayId INT,
	tarih DATE NOT NULL,
	PRIMARY KEY (projeId, calisanId, gorevId, delayId),
	FOREIGN KEY (projeId , calisanId , gorevId)
    REFERENCES görev (projeId , calisanId , gorevId)
    ON DELETE CASCADE
);

CREATE TABLE projedelay (
	projeId  INT,
	delayId  INT,
	tarih DATE NOT NULL,
	PRIMARY KEY (projeId, delayId),
	FOREIGN KEY (projeId)
    REFERENCES proje (projeId)
    ON DELETE CASCADE
);

-- -----------------------------------------------------
-- TABLOLAR END
-- -----------------------------------------------------

-- -----------------------------------------------------
-- STORED PROCEDURES START
-- -----------------------------------------------------

DELIMITER //
	
    -- PROJE START

CREATE PROCEDURE yeniProje(
	IN newprojeAd VARCHAR(20),
    IN newbaslangicTarihi DATE,
    IN newbitisTarihi DATE
)
BEGIN
		INSERT INTO proje (projeAd, baslangicTarihi, bitisTarihi)
		VALUES (newprojeAd, newbaslangicTarihi, newbitisTarihi);
END//

CREATE PROCEDURE silProje(IN sprojeId INT)
BEGIN
    DELETE FROM proje WHERE projeId = sprojeId;
    DELETE FROM projedelay WHERE projeId = sprojeId;
    DELETE FROM görevdelay WHERE projeId = sprojeId;
END//

CREATE PROCEDURE güncelleProje(
	IN gprojeId INT,
    IN newprojeAd VARCHAR(20),
	IN newbaslangicTarihi DATE
)
BEGIN
	DECLARE durum ENUM('Başlanılmadı', 'Aktif', 'Tamamlandı');
    SELECT projeDurum INTO durum FROM proje WHERE projeId = gprojeId;
    
    IF newprojeAd IS NOT NULL THEN
		UPDATE proje SET projeAd = newprojeAd WHERE projeId = gprojeId;
	END IF;

	IF newbaslangicTarihi IS NOT NULL AND durum = 'Tamamlandı'  THEN
		UPDATE proje SET baslangicTarihi = newbaslangicTarihi WHERE projeId = gprojeId;
    END IF;
END//
    
CREATE PROCEDURE projeInfo(IN id INT)
BEGIN
    SELECT 
        CONCAT(g.calisanId, '-', g.gorevId) AS 'Eleman ve Görev Kodları',
        MAX(g.gorevAd) AS 'Görev Adı',
        MAX(g.gorevDurum) AS 'Görev Durumu',
        MAX(c.ad) AS 'Çalışan Adı',
        MAX(c.soyad) AS 'Çalışan Soyadı',
        MAX(g.baslangicTarihi) AS 'Başlangıç Tarihi',
        MAX(g.bitisTarihi) AS 'Bitiş Tarihi',
        COALESCE(DATEDIFF(MAX(gd.tarih), MIN(gd.tarih)), 0) AS 'Gecikme Süresi (Gün)'
    FROM 
        (görev g LEFT JOIN çalışan c ON g.calisanId = c.calisanId) 
        LEFT JOIN proje p ON g.projeId = p.projeId
        LEFT JOIN görevdelay gd ON g.projeId = gd.projeId AND g.calisanId = gd.calisanId AND g.gorevId = gd.gorevId
    WHERE 
        g.projeId = id
    GROUP BY
        g.calisanId, g.gorevId;
END//

CREATE PROCEDURE projeErtele(
    IN dprojeId INT,
    IN newTarih DATE
)
BEGIN
    DECLARE adet INT;
    SELECT COUNT(1) INTO adet FROM proje WHERE projeId = dprojeId;
    INSERT INTO projedelay (projeId, delayId, tarih) VALUES (dprojeId, adet, newTarih);
    UPDATE proje SET bitisTarihi = newTarih WHERE projeId = dprojeId;
END//

CREATE PROCEDURE projeListele()
BEGIN
    SELECT 
        p.projeId AS 'Proje Kodu', 
        p.projeAd AS 'Proje Adı', 
        p.projeDurum AS 'Proje Durumu', 
        p.baslangicTarihi AS 'Başlangıç Tarihi', 
        p.bitisTarihi AS 'Bitiş Tarihi', 
        SUM(CASE WHEN g.gorevDurum = 'Başlanılmadı' THEN 1 ELSE 0 END) AS 'Başlanılmamış Görevler',
        SUM(CASE WHEN g.gorevDurum = 'Aktif' THEN 1 ELSE 0 END) AS 'Aktif Görevler',
        SUM(CASE WHEN g.gorevDurum = 'Tamamlandı' THEN 1 ELSE 0 END) AS 'Tamamlanan Görevler',
        (SELECT COUNT(*) FROM görev g WHERE g.projeId = p.projeId) AS 'Toplam Görev Adedi',
        COALESCE(DATEDIFF(MAX(pd.tarih), MIN(pd.tarih)), 0) AS 'Gecikme Süresi (Gün)'
    FROM proje p 
    LEFT JOIN görev g ON p.projeId = g.projeId
    LEFT JOIN projedelay pd ON p.projeId = pd.projeId
    GROUP BY p.projeId;
END//

CREATE PROCEDURE projeListeleTek(IN id INT)
BEGIN
    SELECT 
        p.projeId AS 'Proje Kodu', 
        p.projeAd AS 'Proje Adı', 
        p.projeDurum AS 'Proje Durumu', 
        p.baslangicTarihi AS 'Başlangıç Tarihi', 
        p.bitisTarihi AS 'Bitiş Tarihi', 
        SUM(CASE WHEN g.gorevDurum = 'Başlanılmadı' THEN 1 ELSE 0 END) AS 'Başlanılmamış Görevler',
        SUM(CASE WHEN g.gorevDurum = 'Aktif' THEN 1 ELSE 0 END) AS 'Aktif Görevler',
        SUM(CASE WHEN g.gorevDurum = 'Tamamlandı' THEN 1 ELSE 0 END) AS 'Tamamlanan Görevler',
        (SELECT COUNT(*) FROM görev g WHERE g.projeId = p.projeId) AS 'Toplam Görev Adedi',
        COALESCE(DATEDIFF(MAX(pd.tarih), MIN(pd.tarih)), 0) AS 'Gecikme Süresi (Gün)'
    FROM proje p 
    LEFT JOIN görev g ON p.projeId = g.projeId
    LEFT JOIN projedelay pd ON p.projeId = pd.projeId
    WHERE p.projeId = id
    GROUP BY p.projeId;
END//

CREATE PROCEDURE tamamlaProje(IN tprojeId INT)
BEGIN
    DECLARE adet INT;
    DELETE FROM projedelay WHERE tarih >= CURRENT_DATE AND projeId = tprojeId;
    SELECT COUNT(1) INTO adet FROM projedelay WHERE projeId = tprojeId;
    INSERT INTO projedelay (projeId, delayId, tarih) VALUES (tprojeId, adet - 1, CURRENT_DATE);
    UPDATE proje SET bitisTarihi = CURRENT_DATE WHERE projeId = tprojeId;
END//

    -- PROJE END

	-- ÇALIŞAN START

CREATE PROCEDURE yeniÇalışan(
	IN newad VARCHAR(20),
    IN newsoyad VARCHAR(20),
    IN newiseAlinmaTarihi DATE
)
BEGIN
	INSERT INTO çalışan (ad, soyad, iseAlinmaTarihi)
    VALUES (newad, newsoyad, newiseAlinmaTarihi);
END//

CREATE PROCEDURE silÇalışan(IN scalisanId INT)
BEGIN
		DELETE FROM çalışan WHERE calisanId = scalisanId;
END//

CREATE PROCEDURE güncelleÇalışan(
IN gcalisanId INT,
IN newad VARCHAR(20),
IN newsoyad VARCHAR(20),
IN newiseAlinmaTarihi DATE
)
BEGIN
	IF newad IS NOT NULL THEN
		UPDATE çalışan SET ad = newad WHERE gcalisanId = calisanId;
	END IF;
	
    IF newsoyad IS NOT NULL THEN
		UPDATE çalışan SET soyad = newsoyad WHERE gcalisanId = calisanId;
	END IF;
	
    IF newiseAlinmaTarihi IS NOT NULL THEN
		UPDATE çalışan SET iseAlinmaTarihi = newiseAlinmaTarihi WHERE gcalisanId = calisanId;
	END IF;
END//

CREATE PROCEDURE çalışanListele()
BEGIN
	SELECT c.calisanId AS 'Çalışan No', c.ad AS 'Ad', c.soyad AS 'Soyad', c.iseAlinmaTarihi AS 'İşe Alınma Tarihi',
    COALESCE ((SELECT g.gorevAd FROM görev g WHERE c.calisanId = g.calisanId AND g.gorevDurum = 'Aktif'), '') AS 'Aktif Görevi'
	FROM çalışan c;
END//

CREATE PROCEDURE çalışanListeleTek(IN id INT)
BEGIN
	SELECT c.calisanId AS 'Çalışan No', c.ad AS 'Ad', c.soyad AS 'Soyad', c.iseAlinmaTarihi AS 'İşe Alınma Tarihi',
    COALESCE ((SELECT g.gorevAd FROM görev g WHERE c.calisanId = g.calisanId AND g.gorevDurum = 'Aktif'), '') AS 'Aktif Görevi'
	FROM çalışan c
    WHERE calisanId = id;
END//

CREATE PROCEDURE çalışanBitGörKıyas(IN id INT)
BEGIN
    SELECT
        SUM(maxdelay = 0) AS 'Zamanında Biten Görevler',
        SUM(maxdelay > 0) AS 'Ertelenerek Biten Görevler'
    FROM (
        SELECT MAX(delayId) AS maxdelay
        FROM görevdelay
        WHERE calisanId = id
        GROUP BY projeId, calisanId, gorevId
    ) AS calisandelay;
END//

CREATE PROCEDURE çalışanInfo(IN id INT)
BEGIN
    SELECT 
        CONCAT(g.projeId, '-', g.gorevId) AS 'Proje ve Görev Kodları',
        g.gorevAd AS 'Görev Adı', 
        g.gorevDurum AS 'Görev Durumu', 
        g.baslangicTarihi AS 'Başlangıç Tarihi', 
        g.bitisTarihi AS 'Bitiş Tarihi',
        COALESCE(DATEDIFF(MAX(gd.tarih), MIN(gd.tarih)), 0) AS 'Gecikme Süresi (Gün)'
    FROM görev g
    LEFT JOIN görevdelay gd ON g.projeId = gd.projeId AND g.calisanId = gd.calisanId AND g.gorevId = gd.gorevId
    WHERE g.calisanId = id
    GROUP BY g.projeId, g.gorevId, g.gorevAd, g.gorevDurum, g.baslangicTarihi, g.bitisTarihi;
END//

    -- ÇALIŞAN END
    
	-- GÖREV START

CREATE PROCEDURE yeniGörev(
	IN newprojeId INT,
    IN newcalisanId INT,
    IN newgorevAd VARCHAR(40),
    IN newbaslangicTarihi DATE,
    IN newbitisTarihi DATE
)
BEGIN
		INSERT INTO görev (projeId, calisanId, gorevAd, baslangicTarihi, bitisTarihi)
		VALUES (newprojeId, newcalisanId, newgorevAd, newbaslangicTarihi, newbitisTarihi);
END//

CREATE PROCEDURE silGörev(
	IN sprojeId INT,
    IN scalisanId INT,
    IN sgorevId INT
)
BEGIN
    DELETE FROM görev WHERE projeId = sprojeId AND calisanId = scalisanId AND gorevId = sgorevId;
    DELETE FROM görevdelay WHERE projeId = sprojeId AND calisanId = scalisanId AND gorevId = sgorevId;
END//

CREATE PROCEDURE güncelleGörev(
    IN gprojeId INT,
    IN gcalisanId INT,
    IN ggorevId INT,
    IN newgorevAd VARCHAR(40),
    IN newbaslangicTarihi DATE
)
BEGIN
	DECLARE durum ENUM('Başlanılmadı', 'Aktif', 'Tamamlandı');
    DECLARE bTarihi DATE;
    SELECT gorevDurum, bitisTarihi INTO durum, bTarihi FROM görev WHERE projeId = gprojeId AND calisanId = gcalisanId AND gorevId = ggorevId;
    
    IF newgorevAd IS NOT NULL THEN
		UPDATE görev SET gorevAd = newgorevAd WHERE projeId = gprojeId AND calisanId = gcalisanId AND gorevId = ggorevId;
	END IF;

	IF durum != 'Tamamlandı' AND newbaslangicTarihi IS NOT NULL THEN
		UPDATE görev SET baslangicTarihi = newbaslangicTarihi WHERE projeId = gprojeId AND calisanId = gcalisanId AND gorevId = ggorevId;
	END IF;
END//

CREATE PROCEDURE görevErtele(
	IN dprojeId INT,
    IN dcalisanId INT,
    IN dgorevId INT,
    IN newTarih DATE
)
BEGIN
	DECLARE adet INT;
    SELECT COUNT(1) INTO adet FROM görev WHERE dprojeId = projeId AND dcalisanId = calisanId AND dgorevId = gorevId;
    INSERT INTO görevdelay (projeId, calisanId, gorevId, delayId, tarih) VALUES (dprojeId, dcalisanId, dgorevId, adet, newTarih);
    UPDATE görev SET bitisTarihi = newTarih WHERE dprojeId = projeId AND dcalisanId = calisanId AND dgorevId = gorevId;
END//

CREATE PROCEDURE görevListele()
BEGIN
    SELECT 
        CONCAT(g.projeId, '-', g.calisanId, '-', g.gorevId) AS 'Proje, Eleman ve Görev Kodları',
        g.gorevAd AS 'Görev Adı', g.gorevDurum AS 'Görev Durumu', 
        p.projeAd AS 'Proje Adı', c.ad AS 'Çalışan Adı', c.soyad AS 'Çalışan Soyadı', 
        g.baslangicTarihi AS 'Başlangıç Tarihi', g.bitisTarihi AS 'Bitiş Tarihi',
        COALESCE(DATEDIFF(MAX(gd.tarih), MIN(gd.tarih)), 0) AS 'Gecikme Süresi (Gün)'
    FROM 
        (görev g 
        LEFT JOIN çalışan c ON g.calisanId = c.calisanId) 
        LEFT JOIN proje p ON g.projeId = p.projeId
        LEFT JOIN görevdelay gd ON g.projeId = gd.projeId AND g.calisanId = gd.calisanId AND g.gorevId = gd.gorevId
    GROUP BY 
        g.projeId, g.calisanId, g.gorevId;
END//

CREATE PROCEDURE görevListeleTek(IN gprojeId INT, IN gcalisanId INT, IN ggorevId INT)
BEGIN
    SELECT 
        CONCAT(g.projeId, '-', g.calisanId, '-', g.gorevId) AS 'Proje, Eleman ve Görev Kodları',
        g.gorevAd AS 'Görev Adı', g.gorevDurum AS 'Görev Durumu', 
        p.projeAd AS 'Proje Adı', c.ad AS 'Çalışan Adı', c.soyad AS 'Çalışan Soyadı', 
        g.baslangicTarihi AS 'Başlangıç Tarihi', g.bitisTarihi AS 'Bitiş Tarihi',
        COALESCE(DATEDIFF(MAX(gd.tarih), MIN(gd.tarih)), 0) AS 'Gecikme Süresi (Gün)'
    FROM 
        (görev g 
        LEFT JOIN çalışan c ON g.calisanId = c.calisanId) 
        LEFT JOIN proje p ON g.projeId = p.projeId
        LEFT JOIN görevdelay gd ON g.projeId = gd.projeId AND g.calisanId = gd.calisanId AND g.gorevId = gd.gorevId
	WHERE 
		g.projeId = gprojeId AND g.calisanId = gcalisanId AND g.gorevId = ggorevId
    GROUP BY 
		g.projeId, g.calisanId, g.gorevId;
END//

CREATE PROCEDURE tamamlaGörev(
	IN tprojeId INT,
    IN tcalisanId INT,
    IN tgorevId INT
)
BEGIN
	DECLARE adet int;
    DELETE FROM görevdelay WHERE tarih >= CURRENT_DATE AND projeId = tprojeId AND calisanId = tcalisanId AND  gorevId = tgorevId;
    SELECT COUNT(1) INTO adet FROM görevdelay WHERE projeId = tprojeId AND calisanId = tcalisanId AND  gorevId = tgorevId;
    INSERT INTO görevdelay (projeId, calisanId, gorevId, delayId, tarih) 
	VALUES (tprojeId, tcalisanId, tgorevId, adet - 1, CURRENT_DATE);
    UPDATE görev SET bitisTarihi = CURRENT_DATE WHERE tprojeId = projeId AND tcalisanId = calisanId AND tgorevId = gorevId;
END//

	-- GÖREV END

DELIMITER ;

-- -----------------------------------------------------
-- STORED PROCEDURES END
-- -----------------------------------------------------

-- -----------------------------------------------------
-- TRIGGER START
-- -----------------------------------------------------

DELIMITER //
CREATE TRIGGER projeDurumBelirle
BEFORE INSERT ON proje
FOR EACH ROW
BEGIN
    IF NEW.baslangicTarihi > CURRENT_DATE THEN
            SET NEW.projeDurum = 'Başlanılmadı';
    ELSE
        IF NEW.bitisTarihi <= CURRENT_DATE THEN
            SET NEW.projeDurum = 'Tamamlandı';
		ELSE
            SET NEW.projeDurum = 'Aktif';
        END IF;
    END IF;
END//

CREATE TRIGGER projeDurumKontrol
BEFORE UPDATE ON proje
FOR EACH ROW
BEGIN
	IF NEW.baslangicTarihi > CURRENT_DATE THEN
		IF NEW.projeDurum != 'Başlanılmadı' THEN
			SET NEW.projeDurum = 'Başlanılmadı';
		END IF;
	ELSE
		IF NEW.bitisTarihi <= CURRENT_DATE AND NEW.projeDurum != 'Tamamlandı' THEN
			SET NEW.projeDurum = 'Tamamlandı';
		ELSEIF NEW.bitisTarihi > CURRENT_DATE AND NEW.projeDurum != 'Aktif' THEN
			SET NEW.projeDurum = 'Aktif';
		END IF;
	END IF;
END//

CREATE TRIGGER yeniProjeDelay
AFTER INSERT ON proje
FOR EACH ROW
BEGIN
    INSERT INTO projedelay (projeId, delayId, tarih) 
    VALUES (NEW.projeId, 0, NEW.bitisTarihi);
END//

CREATE TRIGGER Increment_gorevId
BEFORE INSERT ON görev
FOR EACH ROW
BEGIN
    DECLARE adet INT;
    IF NEW.gorevId IS NULL THEN
        SELECT COUNT(projeId) INTO adet FROM görev WHERE projeId = NEW.projeId AND calisanId = NEW.calisanId;
        SET NEW.gorevId = adet + 1;
    END IF;
END//

CREATE TRIGGER görevDurumBelirle
BEFORE INSERT ON görev
FOR EACH ROW
BEGIN
    IF NEW.baslangicTarihi > CURRENT_DATE THEN
            SET NEW.gorevDurum = 'Başlanılmadı';
    ELSE
        IF NEW.bitisTarihi <= CURRENT_DATE THEN
            SET NEW.gorevDurum = 'Tamamlandı';
		ELSE
            SET NEW.gorevDurum = 'Aktif';
        END IF;
    END IF;
END//

CREATE TRIGGER görevDurumKontrol
BEFORE UPDATE ON görev
FOR EACH ROW
BEGIN
	IF NEW.baslangicTarihi > CURRENT_DATE THEN
		IF NEW.gorevDurum != 'Başlanılmadı' THEN
			SET NEW.gorevDurum = 'Başlanılmadı';
		END IF;
	ELSE
		IF NEW.bitisTarihi <= CURRENT_DATE AND NEW.gorevDurum != 'Tamamlandı' THEN
			SET NEW.gorevDurum = 'Tamamlandı';
		ELSEIF NEW.bitisTarihi > CURRENT_DATE AND NEW.gorevDurum != 'Aktif' THEN
			SET NEW.gorevDurum = 'Aktif';
		END IF;
	END IF;
END//

CREATE TRIGGER yeniGörevDelay
AFTER INSERT ON görev
FOR EACH ROW
BEGIN
    INSERT INTO görevdelay (projeId, calisanId, gorevId, delayId, tarih) 
    VALUES (NEW.projeId, NEW.calisanId, NEW.gorevId, 0, NEW.bitisTarihi);
END//
DELIMITER ;

-- -----------------------------------------------------
-- TRIGGER END
-- -----------------------------------------------------