CREATE TABLE IF NOT EXISTS `books` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Author` longtext NOT NULL,
  `Launch_Date` datetime(6) NOT NULL,
  `Price` decimal(65,2) NOT NULL,
  `Title` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
)
