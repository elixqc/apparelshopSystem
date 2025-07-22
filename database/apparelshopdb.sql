-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: apparelshopdb
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `brands`
--

DROP TABLE IF EXISTS `brands`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brands` (
  `brand_id` int(11) NOT NULL AUTO_INCREMENT,
  `brand_name` varchar(100) NOT NULL,
  `supplier_id` int(11) NOT NULL,
  PRIMARY KEY (`brand_id`),
  KEY `supplier_id` (`supplier_id`),
  CONSTRAINT `brands_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brands`
--

LOCK TABLES `brands` WRITE;
/*!40000 ALTER TABLE `brands` DISABLE KEYS */;
INSERT INTO `brands` VALUES (1,'TrendWear',1),(2,'Metrostyle',3),(3,'UrbanThreads',2);
/*!40000 ALTER TABLE `brands` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cart`
--

DROP TABLE IF EXISTS `cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart` (
  `customer_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `size` varchar(10) DEFAULT NULL,
  `date_added` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`customer_id`,`product_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `cart_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE CASCADE,
  CONSTRAINT `cart_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart`
--

LOCK TABLES `cart` WRITE;
/*!40000 ALTER TABLE `cart` DISABLE KEYS */;
/*!40000 ALTER TABLE `cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category_name` varchar(50) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'T-Shirts'),(2,'Sweatshirts'),(3,'Jeans'),(4,'Jackets'),(5,'Dresses'),(6,'Shorts'),(7,'Eau de Parfum'),(8,'Eau de Toilette'),(9,'Cologne'),(10,'Body Mist'),(11,'Perfume Oil'),(12,'Fragrance Set');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `customer_id` int(11) NOT NULL AUTO_INCREMENT,
  `full_name` varchar(100) NOT NULL,
  `contact_number` varchar(20) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`customer_id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'nico barredo','09392891165','291 zamora st. brgy pinagsama taguig city','nico.barredo@tup.edu.ph','7661f83e32e9b6467f2bb50619049fd8951c266665967ebb678a10d520a36de1'),(2,'nico','09392891165','291','nico@gmail.com','b18aaa6c6b929b866051b69a785a6cdce5bdd564d41be247c7d5ef7c2e2e2271'),(3,'joseph','0939412331','taguig city','joseph@gmail.com','7ee8118150e0ce023742beba6f10bf23aabbf0bc2c182f36fd1a6753cd21b4c6');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_details`
--

DROP TABLE IF EXISTS `order_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_details` (
  `order_detail_id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`order_detail_id`),
  KEY `fk_detail_order` (`order_id`),
  KEY `fk_detail_product` (`product_id`),
  CONSTRAINT `fk_detail_order` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_detail_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_details`
--

LOCK TABLES `order_details` WRITE;
/*!40000 ALTER TABLE `order_details` DISABLE KEYS */;
INSERT INTO `order_details` VALUES (1,1,16,2,599.00),(2,1,33,1,599.00);
/*!40000 ALTER TABLE `order_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT current_timestamp(),
  `order_status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`order_id`),
  KEY `fk_order_customer` (`customer_id`),
  CONSTRAINT `fk_order_customer` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,2,'2025-07-22 12:03:41','Pending');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `product_id` int(11) NOT NULL AUTO_INCREMENT,
  `product_name` varchar(100) NOT NULL,
  `color` varchar(50) DEFAULT NULL,
  `category_id` int(11) DEFAULT NULL,
  `supplier_id` int(11) DEFAULT NULL,
  `size` varchar(20) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) NOT NULL DEFAULT 0,
  `image_path` varchar(255) DEFAULT NULL,
  `brand_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`product_id`),
  KEY `fk_product_category` (`category_id`),
  KEY `fk_product_supplier` (`supplier_id`),
  KEY `fk_brand` (`brand_id`),
  CONSTRAINT `fk_brand` FOREIGN KEY (`brand_id`) REFERENCES `brands` (`brand_id`),
  CONSTRAINT `fk_product_category` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`) ON DELETE SET NULL,
  CONSTRAINT `fk_product_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Sweatshirt - Black - s','black',2,1,'S',599.00,50,'images\\black_swsh.png',1),(2,'Sweatshirt - Black - m','black',2,1,'M',599.00,10,'images\\black_swsh.png',1),(3,'Sweatshirt - Black - l','black',2,1,'L',599.00,10,'images\\black_swsh.png',1),(4,'Sweatshirt - Black - xl','black',2,1,'XL',599.00,10,'images\\black_swsh.png',1),(5,'Sweatshirt - Gray - s','gray',2,1,'S',599.00,10,'images\\gray_swsh.png',1),(6,'Sweatshirt - Gray - m','gray',2,1,'M',599.00,10,'images\\gray_swsh.png',1),(7,'Sweatshirt - Gray - l','gray',2,1,'L',599.00,10,'images\\gray_swsh.png',1),(8,'Sweatshirt - Gray - xl','gray',2,1,'XL',599.00,10,'images\\gray_swsh.png',1),(9,'Sweatshirt - Pink - s','pink',2,1,'S',599.00,10,'images\\pink_swsh.png',1),(10,'Sweatshirt - Pink - m','pink',2,1,'M',599.00,10,'images\\pink_swsh.png',1),(11,'Sweatshirt - Pink - l','pink',2,1,'L',599.00,10,'images\\pink_swsh.png',1),(12,'Sweatshirt - Pink - xl','pink',2,1,'XL',599.00,10,'images\\pink_swsh.png',1),(13,'Sweatshirt - Yellow - s','yellow',2,1,'S',599.00,10,'images\\yellow_swsh.png',1),(14,'Sweatshirt - Yellow - m','yellow',2,1,'M',599.00,10,'images\\yellow_swsh.png',1),(15,'Sweatshirt - Yellow - l','yellow',2,1,'L',599.00,10,'images\\yellow_swsh.png',1),(16,'Sweatshirt - Yellow - xl','yellow',2,1,'XL',599.00,10,'images\\yellow_swsh.png',1),(17,'Sweatshirt - White - xl','white',2,1,'XL',599.00,10,'images\\white_swsh.png',1),(18,'Sweatshirt - White - l','white',2,1,'L',599.00,10,'images\\white_swsh.png',1),(19,'Sweatshirt - White - m','white',2,1,'M',599.00,10,'images\\white_swsh.png',1),(20,'Sweatshirt - White - s','white',2,1,'S',599.00,10,'images\\white_swsh.png',1),(21,'T-shirt - Green - s','green',1,2,'S',599.00,10,'images\\green_shirt1.png',3),(22,'T-shirt - Green - m','green',1,2,'M',599.00,10,'images\\green_shirt1.png',3),(23,'T-shirt - Green - l','green',1,2,'L',599.00,10,'images\\green_shirt1.png',3),(24,'T-shirt - Green - xl','green',1,2,'XL',599.00,10,'images\\green_shirt1.png',3),(25,'T-shirt - White - s','white',1,2,'S',599.00,10,'images\\white_shirt1.png',3),(26,'T-shirt - White - m','white',1,2,'M',599.00,10,'images\\white_shirt1.png',3),(27,'T-shirt - White - l','white',1,2,'L',599.00,10,'images\\white_shirt1.png',3),(28,'T-shirt - White - xl','white',1,2,'XL',599.00,10,'images\\white_shirt1.png',3),(29,'T-shirt - Brown - s','brown',1,2,'S',599.00,10,'images\\brown_shirt1.png',1),(30,'T-shirt - Brown - m','brown',1,2,'M',599.00,10,'images\\brown_shirt1.png',1),(31,'T-shirt - Brown - l','brown',1,2,'L',599.00,10,'images\\brown_shirt1.png',1),(32,'T-shirt - Brown - xl','brown',1,2,'XL',599.00,10,'images\\brown_shirt1.png',1),(33,'T-shirt - Blue - xl','blue',1,2,'XL',599.00,10,'images\\blue_shirt1.png',1),(34,'T-shirt - Blue - l','blue',1,2,'L',599.00,10,'images\\blue_shirt1.png',1),(35,'T-shirt - Blue - m','blue',1,2,'M',599.00,10,'images\\blue_shirt1.png',1),(36,'T-shirt - Blue - s','blue',1,2,'S',599.00,10,'images\\blue_shirt1.png',1),(37,'Oversizedhoodie - Yellow - s','yellow',4,3,'S',999.00,10,'images\\yellow_hoodie.png',2),(38,'Oversizedhoodie - Yellow - m','yellow',4,3,'M',999.00,10,'images\\yellow_hoodie.png',2),(39,'Oversizedhoodie - Yellow - l','yellow',4,3,'L',999.00,10,'images\\yellow_hoodie.png',2),(40,'Oversizedhoodie - Yellow - xl','yellow',4,3,'XL',999.00,10,'images\\yellow_hoodie.png',2),(41,'Oversizedhoodie - Red - xl','red',4,3,'XL',999.00,10,'images\\red_hoodie.png',2),(42,'Oversizedhoodie - Red - l','red',4,3,'L',999.00,10,'images\\red_hoodie.png',2),(43,'Oversizedhoodie - Red - m','red',4,3,'M',999.00,10,'images\\red_hoodie.png',2),(44,'Oversizedhoodie - Red - s','red',4,3,'S',999.00,10,'images\\red_hoodie.png',2),(45,'Oversizedhoodie - Blue - s','blue',4,3,'S',999.00,10,'images\\blue_hoodie.png',2),(46,'Oversizedhoodie - Blue - m','blue',4,3,'M',999.00,10,'images\\blue_hoodie.png',2),(47,'Oversizedhoodie - Blue - l','blue',4,3,'L',999.00,10,'images\\blue_hoodie.png',2),(48,'Oversizedhoodie - Blue - xl','blue',4,3,'XL',999.00,10,'images\\blue_hoodie.png',2),(49,'Oversizedhoodie - Pink - xl','pink',4,3,'XL',999.00,10,'images\\pink_hoodie.png',2),(50,'Oversizedhoodie - Pink - l','pink',4,3,'L',999.00,10,'images\\pink_hoodie.png',2),(51,'Oversizedhoodie - Pink - m','pink',4,3,'M',999.00,10,'images\\pink_hoodie.png',2),(52,'Oversizedhoodie - Pink - s','pink',4,3,'S',999.00,10,'images\\pink_hoodie.png',2),(53,'Sweatpants - White - s','white',3,1,'S',799.00,10,'images\\white_sweatpants.png',1),(54,'Sweatpants - White - m','white',3,1,'M',799.00,10,'images\\white_sweatpants.png',1),(55,'Sweatpants - White - l','white',3,1,'L',799.00,10,'images\\white_sweatpants.png',1),(56,'Sweatpants - White - xl','white',3,1,'XL',799.00,10,'images\\white_sweatpants.png',1),(57,'Sweatpants - Gray - xl','gray',3,1,'XL',799.00,10,'images\\gray_Sweatpants.png',1),(58,'Sweatpants - Gray - l','gray',3,1,'L',799.00,10,'images\\gray_Sweatpants.png',1),(59,'Sweatpants - Gray - m','gray',3,1,'M',799.00,10,'images\\gray_Sweatpants.png',1),(60,'Sweatpants - Gray - s','gray',3,1,'S',799.00,10,'images\\gray_Sweatpants.png',1),(61,'Sweatpants - Black - s','black',3,1,'S',799.00,10,'images\\black_Sweatpants.png',1),(62,'Sweatpants - Black - m','black',3,1,'M',799.00,10,'images\\black_Sweatpants.png',1),(63,'Sweatpants - Black - l','black',3,1,'L',799.00,10,'images\\black_Sweatpants.png',1),(64,'Sweatpants - Black - xl','black',3,1,'XL',799.00,10,'images\\black_Sweatpants.png',1),(65,'Love Spell','Pink',7,4,NULL,1499.00,10,'images\\Lovespell.jpg',NULL),(66,'Sun Set','Yellow',7,5,NULL,1499.00,10,'images\\Sunset.png',NULL),(67,'Coeur De Rose','Peach',7,4,NULL,1499.00,10,'images\\CoeurDeRose.jpg',NULL),(68,'Afternoon Vibe','Blue',7,4,NULL,1499.00,10,'images\\AfternoonVibe.jpg',NULL),(69,'Dream','Light Blue',7,6,NULL,1499.00,10,'images\\dreamFinal.jpg',NULL),(70,'L\'infinity','Cream',7,6,NULL,1999.00,10,'images\\Linfinity.jpg',NULL),(71,'Origin','Dark Brown',7,6,NULL,1799.00,10,'images\\Origin.jpg',NULL),(72,'Pacific Aura','Teal',7,6,NULL,1299.00,10,'images\\Aura.jpg',NULL),(73,'Love Spell EDT','Pink',8,4,NULL,1199.00,10,'images\\Lovespell.jpg',NULL),(74,'Sun Set EDT','Yellow',8,5,NULL,1199.00,10,'images\\Sunset.jpg',NULL),(75,'Coeur De Rose EDT','Peach',8,4,NULL,1199.00,10,'images\\CoeurDeRose.jpg',NULL),(76,'Afternoon Vibe EDT','Blue',8,4,NULL,1199.00,10,'images\\AfternoonVibe.jpg',NULL),(77,'Dream EDT','Light Blue',8,6,NULL,1199.00,10,'images\\dreamFinal.jpg',NULL),(78,'L\'infinity EDT','Cream',8,6,NULL,1599.00,10,'images\\Linfinity.jpg',NULL),(79,'Origin EDT','Dark Brown',8,6,NULL,1399.00,10,'images\\Origin.jpg',NULL),(80,'Pacific Aura EDT','Teal',8,6,NULL,999.00,10,'images\\Aura.jpg',NULL);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `supplier_id` int(11) NOT NULL AUTO_INCREMENT,
  `supplier_name` varchar(100) NOT NULL,
  `contact_person` varchar(100) DEFAULT NULL,
  `contact_number` varchar(20) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`supplier_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'TrendWear Inc.','Anna Cruz','09171234567','Unit 201, Fashion Tower, Makati City'),(2,'Urban Threads Co.','Mike Santos','09281234567','3rd Floor, Textile Hub, Quezon City'),(3,'MetroStyle Apparel','Jane dela Cruz','09391234567','8th Ave, Taguig City'),(4,'Scentify Distributors','Carlos Ramirez','09181239876','Blk 4 Lot 22, Aroma St., Pasig City'),(5,'Fragrance World','Ella Gomez','09292234567','Perfume Lane, Ortigas Center'),(6,'Aromatique Corp.','Leo Fernandez','09452236789','Lot 6, Essence Village, San Juan City');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supply_logs`
--

DROP TABLE IF EXISTS `supply_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supply_logs` (
  `supply_id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `supplier_id` int(11) NOT NULL,
  `quantity_added` int(11) NOT NULL,
  `supply_date` datetime DEFAULT current_timestamp(),
  `remarks` text DEFAULT NULL,
  `supplier_price` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`supply_id`),
  KEY `fk_supply_product` (`product_id`),
  KEY `fk_supply_supplier` (`supplier_id`),
  CONSTRAINT `fk_supply_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_supply_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supply_logs`
--

LOCK TABLES `supply_logs` WRITE;
/*!40000 ALTER TABLE `supply_logs` DISABLE KEYS */;
INSERT INTO `supply_logs` VALUES (2,1,1,10,'2025-07-21 16:27:08','added sweatshirt small black 10pcs',10.00),(3,1,1,0,'2025-07-21 21:18:14','',499.00);
/*!40000 ALTER TABLE `supply_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'elixqc','7661f83e32e9b6467f2bb50619049fd8951c266665967ebb678a10d520a36de1');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-22 18:31:46
