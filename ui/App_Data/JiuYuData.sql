/*
SQLyog Ultimate v8.71 
MySQL - 5.0.41-community-nt : Database - jiuyu
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`jiuyu` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `jiuyu`;

/*Table structure for table `adminuser` */

DROP TABLE IF EXISTS `adminuser`;

CREATE TABLE `adminuser` (
  `id` int(11) NOT NULL auto_increment,
  `userName` varchar(20) NOT NULL,
  `passwordC` varchar(50) default NULL,
  `timeC` varchar(20) default NULL,
  `historyC` text,
  `nameC` varchar(50) default NULL,
  `telC` varchar(20) default NULL,
  `typ` int(11) default NULL,
  PRIMARY KEY  (`id`),
  KEY `userName` (`userName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `adminuser` */

/*Table structure for table `atrr` */

DROP TABLE IF EXISTS `atrr`;

CREATE TABLE `atrr` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(255) default NULL,
  `valueC` varchar(255) default NULL,
  `typ` varchar(255) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `atrr` */

/*Table structure for table `box` */

DROP TABLE IF EXISTS `box`;

CREATE TABLE `box` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(255) default NULL,
  `sizeC` varchar(255) default NULL,
  `weightC` int(11) default NULL,
  `imgC` varchar(255) default NULL,
  `priceC` varchar(255) default NULL,
  `aboutC` text,
  `countC` text,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `box` */

/*Table structure for table `brand` */

DROP TABLE IF EXISTS `brand`;

CREATE TABLE `brand` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(50) default NULL,
  `imgC` varchar(50) default NULL,
  `aboutC` text NOT NULL,
  `typ` int(11) NOT NULL,
  `sortC` int(11) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `brand` */

/*Table structure for table `color` */

DROP TABLE IF EXISTS `color`;

CREATE TABLE `color` (
  `id` int(11) NOT NULL auto_increment,
  `colorC` varchar(50) default NULL COMMENT '颜色',
  `tipsC` varchar(500) default NULL COMMENT '描述',
  `typ` int(11) default NULL COMMENT '产品id',
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `color` */

/*Table structure for table `coupon` */

DROP TABLE IF EXISTS `coupon`;

CREATE TABLE `coupon` (
  `id` int(11) NOT NULL auto_increment,
  `numC` varchar(50) default NULL,
  `typ` int(11) default NULL,
  `priceC` decimal(10,0) default NULL,
  `tipsC` text,
  `userId` int(11) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `coupon` */

/*Table structure for table `exppay` */

DROP TABLE IF EXISTS `exppay`;

CREATE TABLE `exppay` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(50) default NULL,
  `tipsC` varchar(50) default NULL,
  `priceC` decimal(10,0) default NULL,
  `typ` int(11) default NULL,
  `sortC` int(11) default NULL,
  `imgC` varchar(100) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `exppay` */

/*Table structure for table `expplace` */

DROP TABLE IF EXISTS `expplace`;

CREATE TABLE `expplace` (
  `placeId` int(11) default NULL,
  `priceC` decimal(10,0) default NULL,
  `typ` int(11) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `expplace` */

/*Table structure for table `flash` */

DROP TABLE IF EXISTS `flash`;

CREATE TABLE `flash` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(50) default NULL,
  `imgC` varchar(100) default NULL,
  `urlC` varchar(50) default NULL,
  `typS` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `flash` */

/*Table structure for table `img` */

DROP TABLE IF EXISTS `img`;

CREATE TABLE `img` (
  `imgC` varchar(100) default NULL,
  `typ` int(11) default NULL COMMENT '类别',
  `sortC` int(11) default NULL COMMENT '排序',
  `id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `img` */

/*Table structure for table `keywords` */

DROP TABLE IF EXISTS `keywords`;

CREATE TABLE `keywords` (
  `id` int(11) NOT NULL default '0',
  `titleC` varchar(500) default NULL,
  `keywordsC` varchar(500) default NULL,
  `descriptionC` text,
  `typS` varchar(50) default NULL,
  `tipsC` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `keywords` */

/*Table structure for table `link` */

DROP TABLE IF EXISTS `link`;

CREATE TABLE `link` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(50) default NULL,
  `urlC` varchar(50) default NULL,
  `typS` varchar(50) default NULL,
  `logo` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `link` */

/*Table structure for table `menu` */

DROP TABLE IF EXISTS `menu`;

CREATE TABLE `menu` (
  `id` int(11) NOT NULL default '0',
  `nameC` varchar(50) default NULL,
  `levelC` varchar(50) default NULL,
  `urlC` varchar(100) default NULL,
  `displayC` int(11) default NULL,
  `flgC` int(11) default NULL,
  `sortC` int(11) default NULL,
  `typ` int(11) default NULL,
  `aboutC` text,
  `htmlName` varchar(100) default NULL,
  `countC` int(11) default NULL,
  `preId` varchar(255) default NULL,
  `sonId` varchar(255) default NULL,
  `topKey` text,
  `titleC` varchar(500) default NULL,
  `keywordesC` varchar(500) default NULL,
  `descriptionC` text,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `menu` */

/*Table structure for table `message` */

DROP TABLE IF EXISTS `message`;

CREATE TABLE `message` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(50) default NULL,
  `telC` varchar(50) default NULL,
  `mailC` varchar(50) default NULL,
  `addressC` varchar(50) default NULL,
  `timeC` varchar(50) default NULL,
  `product` varchar(100) default NULL,
  `typ` int(11) default NULL,
  `ipC` varchar(20) default NULL,
  `contentC` text,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `message` */

/*Table structure for table `news` */

DROP TABLE IF EXISTS `news`;

CREATE TABLE `news` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(100) default NULL,
  `aboutC` text,
  `contentC` text,
  `htmlName` varchar(500) default NULL,
  `titleC` varchar(500) default NULL,
  `keywordsC` varchar(100) default NULL,
  `descriptionC` varchar(500) default NULL,
  `typS` varchar(50) default NULL,
  `typ` int(11) default NULL,
  `timeC` varchar(20) default NULL,
  `sortC` int(11) default NULL,
  `showC` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `news` */

/*Table structure for table `order` */

DROP TABLE IF EXISTS `order`;

CREATE TABLE `order` (
  `orderC` varchar(255) NOT NULL default '',
  `userName` varchar(50) default NULL,
  `proInfo` text,
  `addinfo` text,
  `timeC` varchar(50) default NULL,
  `payName` varchar(50) default NULL,
  `expName` varchar(50) default NULL,
  `expNum` varchar(50) default NULL,
  `expTime` varchar(50) default NULL,
  `expPrice` decimal(10,0) default NULL,
  `priceC` decimal(10,0) default NULL,
  `typ` int(11) default NULL,
  `remarksC` text,
  `cutCount` varchar(50) default NULL,
  `cutFlg` int(11) default NULL,
  `totalInfo` text,
  `shippingName` varchar(50) default NULL,
  `shippingTel` varchar(20) default NULL,
  `shipingAddress` text,
  `shippingCountry` varchar(50) default NULL,
  PRIMARY KEY  (`orderC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `order` */

/*Table structure for table `orderitem` */

DROP TABLE IF EXISTS `orderitem`;

CREATE TABLE `orderitem` (
  `ID` int(11) NOT NULL auto_increment,
  `OrderID` varchar(50) default NULL,
  `ProductId` varchar(50) default NULL,
  `Quantity` int(11) default NULL,
  `UnitPrice` decimal(10,0) default NULL,
  `TotalAmount` decimal(10,0) default NULL,
  `ProductName` varchar(50) default NULL,
  `CreateDate` date default NULL,
  `HtmlName` varchar(50) default NULL,
  `ProductNO` varchar(50) default NULL,
  `Discounte` int(11) default NULL,
  `DisPrice` decimal(10,0) default NULL,
  `ProImgURL` varchar(50) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `orderitem` */

/*Table structure for table `orderpro` */

DROP TABLE IF EXISTS `orderpro`;

CREATE TABLE `orderpro` (
  `id` int(11) NOT NULL auto_increment,
  `numC` varchar(50) default NULL,
  `img` varchar(50) default NULL,
  `htmlName` varchar(50) default NULL,
  `nameC` varchar(50) default NULL,
  `proId` varchar(50) default NULL,
  `countC` int(11) default NULL,
  `weightC` int(11) default NULL,
  `priceC` decimal(10,0) default NULL,
  `remarkC` text,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `orderpro` */

/*Table structure for table `place` */

DROP TABLE IF EXISTS `place`;

CREATE TABLE `place` (
  `id` int(11) default NULL,
  `nameC` varchar(50) default NULL,
  `sortC` int(11) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `place` */

/*Table structure for table `price` */

DROP TABLE IF EXISTS `price`;

CREATE TABLE `price` (
  `id` int(11) NOT NULL auto_increment,
  `minC` int(11) default NULL,
  `maxC` int(11) default NULL,
  `typ` int(11) default NULL,
  `dayC` varchar(20) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `price` */

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(50) default NULL,
  `proId` varchar(50) default NULL,
  `fileName` varchar(50) default NULL,
  `imgC` varchar(50) default NULL,
  `displayC` varchar(50) default NULL,
  `priceC` decimal(10,0) default NULL,
  `htmlName` varchar(50) default NULL,
  `sortC` int(11) default NULL,
  `typ` int(11) default NULL,
  `weightC` int(11) default NULL,
  `qx` int(11) default NULL,
  `aboutC` text,
  `stockC` varchar(100) default NULL,
  `strPrice` varchar(50) default NULL,
  `showC` int(11) default NULL,
  `sellCount` int(11) default NULL,
  `addType` varchar(500) default NULL,
  `brandC` text,
  `star` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `products` */

/*Table structure for table `proinfo` */

DROP TABLE IF EXISTS `proinfo`;

CREATE TABLE `proinfo` (
  `proId` int(11) NOT NULL,
  `titelC` varchar(100) default NULL,
  `keywordsC` varchar(200) default NULL,
  `descriptionC` text,
  `contentC` text,
  `moqC` varchar(100) default NULL,
  `attrId` varchar(50) default NULL,
  `attrValue` varchar(100) default NULL,
  `addTypeName` varchar(100) default NULL,
  `moreIg` text,
  PRIMARY KEY  (`proId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `proinfo` */

/*Table structure for table `returnorder` */

DROP TABLE IF EXISTS `returnorder`;

CREATE TABLE `returnorder` (
  `id` int(11) NOT NULL auto_increment,
  `orderC` varchar(50) default NULL,
  `userName` varchar(50) default NULL,
  `methodC` varchar(50) default NULL,
  `priceC` varchar(50) default NULL,
  `reasonC` varchar(500) default NULL,
  `proList` varchar(500) default NULL,
  `typ` int(20) default NULL,
  `nessageC` text,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `returnorder` */

/*Table structure for table `searchwords` */

DROP TABLE IF EXISTS `searchwords`;

CREATE TABLE `searchwords` (
  `id` int(11) NOT NULL auto_increment,
  `nameC` varchar(50) default NULL,
  `countC` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `searchwords` */

/*Table structure for table `supply` */

DROP TABLE IF EXISTS `supply`;

CREATE TABLE `supply` (
  `id` int(11) NOT NULL auto_increment,
  `sname` varchar(50) default NULL,
  `contactus` text,
  `phone` varchar(20) default NULL,
  `address` varchar(500) default NULL,
  `mail` varchar(50) default NULL,
  `agentyp` varchar(50) default NULL,
  `abrand` varchar(50) default NULL,
  `Banks` varchar(200) default NULL,
  `account` varchar(100) default NULL,
  `raddress` varchar(500) default NULL,
  `rcontact` varchar(500) default NULL,
  `rphone` varchar(50) default NULL,
  `times` varchar(20) default NULL,
  `note1` varchar(500) default NULL,
  `note2` varchar(500) default NULL,
  `note3` varchar(500) default NULL,
  `note4` varchar(500) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `supply` */

/*Table structure for table `supplyvalue` */

DROP TABLE IF EXISTS `supplyvalue`;

CREATE TABLE `supplyvalue` (
  `id` int(11) NOT NULL auto_increment,
  `name` varchar(50) default NULL,
  `types` varchar(50) default NULL,
  `value` varchar(500) default NULL,
  `note2` varchar(500) default NULL,
  `note3` varchar(500) default NULL,
  `nodte4` varchar(500) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `supplyvalue` */

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `id` int(11) NOT NULL auto_increment,
  `userName` varchar(50) default NULL,
  `passwordC` varchar(50) default NULL,
  `descriptionC` text,
  `nameC` varchar(50) default NULL,
  `telC` varchar(20) default NULL,
  `mailC` varchar(50) default NULL,
  `timeC` varchar(20) default NULL,
  `addressC` varchar(500) default NULL,
  `integralC` int(11) default NULL,
  `levelC` varchar(50) default NULL,
  `loginTime` varchar(50) default NULL,
  `typ` int(11) default NULL,
  `countryC` varchar(200) default NULL,
  `loginCount` int(11) default NULL,
  `moneyC` varchar(50) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `user` */

insert  into `user`(`id`,`userName`,`passwordC`,`descriptionC`,`nameC`,`telC`,`mailC`,`timeC`,`addressC`,`integralC`,`levelC`,`loginTime`,`typ`,`countryC`,`loginCount`,`moneyC`) values (2,'ass@ads.ee','1','','??','???','','2012-7-19 17:07:36','??',0,'99','',0,'',0,'');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
