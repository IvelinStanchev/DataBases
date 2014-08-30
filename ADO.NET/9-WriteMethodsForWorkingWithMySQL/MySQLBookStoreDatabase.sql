SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema BookStore
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `BookStore` ;
CREATE SCHEMA IF NOT EXISTS `BookStore` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `BookStore` ;

-- -----------------------------------------------------
-- Table `BookStore`.`Books`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BookStore`.`Books` (
  `BookID` INT NOT NULL,
  `Title` VARCHAR(50) NOT NULL,
  `Author` VARCHAR(50) NOT NULL,
  `PublishDate` DATETIME NOT NULL,
  `ISBN` INT NOT NULL,
  PRIMARY KEY (`BookID`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
