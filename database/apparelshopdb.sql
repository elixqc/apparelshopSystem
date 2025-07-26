-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 26, 2025 at 08:21 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `apparelshopdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `brands`
--

CREATE TABLE `brands` (
  `brand_id` int(11) NOT NULL,
  `brand_name` varchar(100) NOT NULL,
  `supplier_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `brands`
--

INSERT INTO `brands` (`brand_id`, `brand_name`, `supplier_id`) VALUES
(1, 'TrendWear', 1),
(2, 'Metrostyle', 3),
(3, 'UrbanThreads', 2);

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE `cart` (
  `customer_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `size` varchar(10) DEFAULT NULL,
  `date_added` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`category_id`, `category_name`) VALUES
(1, 'T-Shirts'),
(2, 'Sweatshirts'),
(3, 'Jeans'),
(4, 'Jackets'),
(5, 'Dresses'),
(6, 'Shorts'),
(7, 'Eau de Parfum'),
(8, 'Eau de Toilette');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `customer_id` int(11) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `contact_number` varchar(20) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`customer_id`, `full_name`, `contact_number`, `address`, `email`, `password`) VALUES
(1, 'nico barredo', '09392891165', '291 zamora st. brgy pinagsama taguig city', 'nico.barredo@tup.edu.ph', '7661f83e32e9b6467f2bb50619049fd8951c266665967ebb678a10d520a36de1'),
(2, 'nico', '09294585592', '291 Zamora St. Brgy. Pinagsama Taguig City', 'nico@gmail.com', 'b18aaa6c6b929b866051b69a785a6cdce5bdd564d41be247c7d5ef7c2e2e2271'),
(3, 'joseph', '0939412331', 'taguig city', 'joseph@gmail.com', '7ee8118150e0ce023742beba6f10bf23aabbf0bc2c182f36fd1a6753cd21b4c6'),
(5, 'nico barredo', '1', 'testing', 'a', 'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb'),
(6, 'lloyd forger', '091243141632', 'Block 2 Lot 8 Camella Residence Brgy. Pinagsama Taguig City', 'forger@gmail.com', '814ccdfae0812b1bd9a95ae4b4a7d7d128890d1859cf8fd3e4c4befb22e63e8f');

-- --------------------------------------------------------

--
-- Table structure for table `notifications`
--

CREATE TABLE `notifications` (
  `notification_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `message` varchar(255) NOT NULL,
  `is_read` tinyint(1) DEFAULT 0,
  `date_created` datetime DEFAULT current_timestamp(),
  `customer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `notifications`
--

INSERT INTO `notifications` (`notification_id`, `order_id`, `message`, `is_read`, `date_created`, `customer_id`) VALUES
(1, 1, 'Your order #1 has been completed. Click to download your receipt.', 1, '2025-07-26 13:48:15', 5),
(2, 2, 'Order #2 cancelled. Payment Unsuccesful. Payment Did Not Received!!!', 1, '2025-07-26 14:00:11', 5),
(3, 3, 'Your order #3 has been completed. Click to download your receipt.', 1, '2025-07-26 14:07:32', 5),
(4, 4, 'Order #4 cancelled. INVALID PAYMENT. REFERENCE NUMBER DO NOT EXISTS!!', 1, '2025-07-26 14:08:09', 5),
(5, 5, 'Order #5 cancelled. INVALID PAYMENT REFERENCE NUMBER!!!!', 0, '2025-07-26 14:14:10', 5),
(6, 6, 'Your order #6 has been completed. Click to download your receipt.', 1, '2025-07-26 14:18:06', 5);

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT current_timestamp(),
  `order_status` varchar(20) DEFAULT NULL,
  `date_received` datetime DEFAULT NULL,
  `delivery_address` text DEFAULT NULL,
  `payment_method` varchar(50) DEFAULT 'COD',
  `payment_reference` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`order_id`, `customer_id`, `order_date`, `order_status`, `date_received`, `delivery_address`, `payment_method`, `payment_reference`) VALUES
(1, 5, '2025-07-26 13:47:27', 'Completed', '2025-07-26 13:48:15', 'testing', 'eWallet', '54356675234324252'),
(2, 5, '2025-07-26 13:58:35', 'Cancelled', NULL, 'testing', 'eWallet', '24643524123213'),
(3, 5, '2025-07-26 14:06:40', 'Completed', '2025-07-26 14:07:32', 'testing', 'COD', NULL),
(4, 5, '2025-07-26 14:06:59', 'Cancelled', NULL, 'testing', 'eWallet', '231412541231'),
(5, 5, '2025-07-26 14:13:26', 'Cancelled', NULL, 'testing', 'eWallet', '12545324123124321'),
(6, 5, '2025-07-26 14:17:46', 'Completed', '2025-07-26 14:18:06', 'testing', 'eWallet', '414533123124');

-- --------------------------------------------------------

--
-- Table structure for table `order_details`
--

CREATE TABLE `order_details` (
  `order_detail_id` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `order_details`
--

INSERT INTO `order_details` (`order_detail_id`, `order_id`, `product_id`, `quantity`, `unit_price`) VALUES
(1, 1, 20, 1, 599.00),
(2, 2, 32, 1, 499.00),
(3, 3, 21, 1, 499.00),
(4, 4, 88, 1, 1999.00),
(5, 5, 100, 1, 2099.00),
(6, 6, 20, 1, 599.00);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL,
  `product_name` varchar(100) NOT NULL,
  `color` varchar(50) DEFAULT NULL,
  `category_id` int(11) DEFAULT NULL,
  `supplier_id` int(11) DEFAULT NULL,
  `size` varchar(20) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) NOT NULL DEFAULT 0,
  `image_path` varchar(255) DEFAULT NULL,
  `gender` varchar(20) NOT NULL,
  `brand_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `color`, `category_id`, `supplier_id`, `size`, `price`, `stock_quantity`, `image_path`, `gender`, `brand_id`) VALUES
(1, 'Sweatshirt - Yellow - s', 'yellow', 2, 1, 'S', 599.00, 9, 'images\\yellow_swsh.png', 'Unisex', 1),
(2, 'Sweatshirt - Yellow - m', 'yellow', 2, 1, 'M', 599.00, 10, 'images\\yellow_swsh.png', 'Unisex', 1),
(3, 'Sweatshirt - Yellow - l', 'yellow', 2, 1, 'L', 599.00, 10, 'images\\yellow_swsh.png', 'Unisex', 1),
(4, 'Sweatshirt - Yellow - xl', 'yellow', 2, 1, 'XL', 599.00, 4, 'images\\yellow_swsh.png', 'Unisex', 1),
(5, 'Sweatshirt - White - xl', 'white', 2, 1, 'XL', 599.00, 10, 'images\\white_swsh.png', 'Unisex', 1),
(6, 'Sweatshirt - White - l', 'white', 2, 1, 'L', 599.00, 10, 'images\\white_swsh.png', 'Unisex', 1),
(7, 'Sweatshirt - White - m', 'white', 2, 1, 'M', 599.00, 10, 'images\\white_swsh.png', 'Unisex', 1),
(8, 'Sweatshirt - White - s', 'white', 2, 1, 'S', 599.00, 10, 'images\\white_swsh.png', 'Unisex', 1),
(9, 'Sweatshirt - Pink - s', 'pink', 2, 1, 'S', 599.00, 10, 'images\\pink_swsh.png', 'Unisex', 1),
(10, 'Sweatshirt - Pink - m', 'pink', 2, 1, 'M', 599.00, 10, 'images\\pink_swsh.png', 'Unisex', 1),
(11, 'Sweatshirt - Pink - l', 'pink', 2, 1, 'L', 599.00, 10, 'images\\pink_swsh.png', 'Unisex', 1),
(12, 'Sweatshirt - Pink - xl', 'pink', 2, 1, 'XL', 599.00, 8, 'images\\pink_swsh.png', 'Unisex', 1),
(13, 'Sweatshirt - Gray - xl', 'gray', 2, 1, 'XL', 599.00, 10, 'images\\gray_swsh.png', 'Unisex', 1),
(14, 'Sweatshirt - Gray - l', 'gray', 2, 1, 'L', 599.00, 10, 'images\\gray_swsh.png', 'Unisex', 1),
(15, 'Sweatshirt - Gray - m', 'gray', 2, 1, 'M', 599.00, 10, 'images\\gray_swsh.png', 'Unisex', 1),
(16, 'Sweatshirt - Gray - s', 'gray', 2, 1, 'S', 599.00, 10, 'images\\gray_swsh.png', 'Unisex', 1),
(17, 'Sweatshirt - Black - s', 'black', 2, 1, 'S', 599.00, 10, 'images\\black_swsh.png', 'Unisex', 1),
(18, 'Sweatshirt - Black - m', 'black', 2, 1, 'M', 599.00, 10, 'images\\black_swsh.png', 'Unisex', 1),
(19, 'Sweatshirt - Black - l', 'black', 2, 1, 'L', 599.00, 8, 'images\\black_swsh.png', 'Unisex', 1),
(20, 'Sweatshirt - Black - xl', 'black', 2, 1, 'XL', 599.00, 3, 'images\\black_swsh.png', 'Unisex', 1),
(21, 'T-shirt - White - s', 'white', 1, 3, 'S', 499.00, 9, 'images\\white_shirt1.png', 'Unisex', 2),
(22, 'T-shirt - White - m', 'white', 1, 3, 'M', 499.00, 0, 'images\\white_shirt1.png', 'Unisex', 2),
(23, 'T-shirt - White - l', 'white', 1, 3, 'L', 499.00, 10, 'images\\white_shirt1.png', 'Unisex', 2),
(24, 'T-shirt - White - xl', 'white', 1, 3, 'XL', 499.00, 7, 'images\\white_shirt1.png', 'Unisex', 2),
(25, 'T-shirt - Green - xl', 'green', 1, 3, 'XL', 499.00, 10, 'images\\green_shirt1.png', 'Unisex', 2),
(26, 'T-shirt - Green - l', 'green', 1, 3, 'L', 499.00, 10, 'images\\green_shirt1.png', 'Unisex', 2),
(27, 'T-shirt - Green - m', 'green', 1, 3, 'M', 499.00, 10, 'images\\green_shirt1.png', 'Unisex', 2),
(28, 'T-shirt - Green - s', 'green', 1, 3, 'S', 499.00, 10, 'images\\green_shirt1.png', 'Unisex', 2),
(29, 'T-shirt - Brown - s', 'brown', 1, 3, 'S', 499.00, 10, 'images\\brown_shirt1.png', 'Unisex', 2),
(30, 'T-shirt - Brown - m', 'brown', 1, 3, 'M', 499.00, 10, 'images\\brown_shirt1.png', 'Unisex', 2),
(31, 'T-shirt - Brown - l', 'brown', 1, 3, 'L', 499.00, 10, 'images\\brown_shirt1.png', 'Unisex', 2),
(32, 'T-shirt - Brown - xl', 'brown', 1, 3, 'XL', 499.00, 8, 'images\\brown_shirt1.png', 'Unisex', 2),
(33, 'T-shirt - Blue - xl', 'blue', 1, 3, 'XL', 499.00, 9, 'images\\blue_shirt1.png', 'Unisex', 2),
(34, 'T-shirt - Blue - l', 'blue', 1, 3, 'L', 499.00, 10, 'images\\blue_shirt1.png', 'Unisex', 2),
(35, 'T-shirt - Blue - m', 'blue', 1, 3, 'M', 499.00, 10, 'images\\blue_shirt1.png', 'Unisex', 2),
(36, 'T-shirt - Blue - s', 'blue', 1, 3, 'S', 499.00, 10, 'images\\blue_shirt1.png', 'Unisex', 2),
(37, 'Hoodie - Yellow - s', 'yellow', 4, 2, 'S', 1099.00, 10, 'images\\yellow_hoodie.png', 'Unisex', 3),
(38, 'Hoodie - Yellow - m', 'yellow', 4, 2, 'M', 1099.00, 10, 'images\\yellow_hoodie.png', 'Unisex', 3),
(39, 'Hoodie - Yellow - l', 'yellow', 4, 2, 'L', 1099.00, 10, 'images\\yellow_hoodie.png', 'Unisex', 3),
(40, 'Hoodie - Yellow - xl', 'yellow', 4, 2, 'XL', 1099.00, 10, 'images\\yellow_hoodie.png', 'Unisex', 3),
(41, 'Hoodie - Yellow - xxl', 'yellow', 4, 2, 'XXL', 1099.00, 10, 'images\\yellow_hoodie.png', 'Unisex', 3),
(42, 'Hoodie - Red - s', 'red', 4, 2, 'S', 1099.00, 10, 'images\\red_hoodie.png', 'Unisex', 3),
(43, 'Hoodie - Red - m', 'red', 4, 2, 'M', 1099.00, 10, 'images\\red_hoodie.png', 'Unisex', 3),
(44, 'Hoodie - Red - l', 'red', 4, 2, 'L', 1099.00, 10, 'images\\red_hoodie.png', 'Unisex', 3),
(45, 'Hoodie - Red - xl', 'red', 4, 2, 'XL', 1099.00, 10, 'images\\red_hoodie.png', 'Unisex', 3),
(46, 'Hoodie - Red - xxl', 'red', 4, 2, 'XXL', 1099.00, 10, 'images\\red_hoodie.png', 'Unisex', 3),
(47, 'Hoodie - Pink - xxl', 'pink', 4, 2, 'XXL', 1099.00, 10, 'images\\pink_hoodie.png', 'Unisex', 3),
(48, 'Hoodie - Pink - xl', 'pink', 4, 2, 'XL', 1099.00, 10, 'images\\pink_hoodie.png', 'Unisex', 3),
(49, 'Hoodie - Pink - l', 'pink', 4, 2, 'L', 1099.00, 10, 'images\\pink_hoodie.png', 'Unisex', 3),
(50, 'Hoodie - Pink - m', 'pink', 4, 2, 'M', 1099.00, 10, 'images\\pink_hoodie.png', 'Unisex', 3),
(51, 'Hoodie - Pink - s', 'pink', 4, 2, 'S', 1099.00, 10, 'images\\pink_hoodie.png', 'Unisex', 3),
(52, 'Hoodie - Blue - s', 'blue', 4, 2, 'S', 1099.00, 10, 'images\\blue_hoodie.png', 'Unisex', 3),
(53, 'Hoodie - Blue - m', 'blue', 4, 2, 'M', 1099.00, 10, 'images\\blue_hoodie.png', 'Unisex', 3),
(54, 'Hoodie - Blue - l', 'blue', 4, 2, 'L', 1099.00, 9, 'images\\blue_hoodie.png', 'Unisex', 3),
(55, 'Hoodie - Blue - xl', 'blue', 4, 2, 'XL', 1099.00, 9, 'images\\blue_hoodie.png', 'Unisex', 3),
(56, 'Hoodie - Blue - xxl', 'blue', 4, 2, 'XXL', 1099.00, 10, 'images\\blue_hoodie.png', 'Unisex', 3),
(57, 'Sweatpants - White - s', 'white', 3, 1, 'S', 799.00, 10, 'images\\white_sweatpants.png', 'Unisex', 1),
(58, 'Sweatpants - White - m', 'white', 3, 1, 'M', 799.00, 10, 'images\\white_sweatpants.png', 'Unisex', 1),
(59, 'Sweatpants - White - l', 'white', 3, 1, 'L', 799.00, 10, 'images\\white_sweatpants.png', 'Unisex', 1),
(60, 'Sweatpants - White - xl', 'white', 3, 1, 'XL', 799.00, -8, 'images\\white_sweatpants.png', 'Unisex', 1),
(61, 'Sweatpants - Black - xl', 'black', 3, 1, 'XL', 799.00, 9, 'images\\black_Sweatpants.png', 'Unisex', 1),
(62, 'Sweatpants - Black - l', 'black', 3, 1, 'L', 799.00, 10, 'images\\black_Sweatpants.png', 'Unisex', 1),
(63, 'Sweatpants - Black - m', 'black', 3, 1, 'M', 799.00, 10, 'images\\black_Sweatpants.png', 'Unisex', 1),
(64, 'Sweatpants - Black - s', 'black', 3, 1, 'S', 799.00, 10, 'images\\black_Sweatpants.png', 'Unisex', 1),
(65, 'Sweatpants - Gray - s', 'gray', 3, 1, 'S', 799.00, 9, 'images\\gray_Sweatpants.png', 'Unisex', 1),
(66, 'Sweatpants - Gray - m', 'gray', 3, 1, 'M', 799.00, 10, 'images\\gray_Sweatpants.png', 'Unisex', 1),
(67, 'Sweatpants - Gray - l', 'gray', 3, 1, 'L', 799.00, 10, 'images\\gray_Sweatpants.png', 'Unisex', 1),
(85, 'dream EDP', NULL, 7, 4, NULL, 1399.00, 8, 'images\\dreamFinal.jpg', 'Male', NULL),
(86, 'love spell EDP', NULL, 7, 4, NULL, 1399.00, 5, 'images\\Lovespell.jpg', 'Female', NULL),
(87, 'origin EDP', NULL, 7, 5, NULL, 1999.00, 1, 'images\\originFinal.jpg', 'Male', NULL),
(88, 'origin EDT', NULL, 8, 5, NULL, 1999.00, 9, 'images\\originFinal.jpg', 'Male', NULL),
(90, 'dream EDT', NULL, 8, 4, NULL, 1899.00, 9, 'imagesdreamFinal.jpg', 'Male', NULL),
(91, 'Linfinite EDP', NULL, 7, 4, NULL, 1799.00, 6, 'images\\Linfinity.jpg', 'Male', NULL),
(92, 'Linfinite EDT', NULL, 8, 4, NULL, 1799.00, 9, 'images\\Linfinity.jpg', 'Male', NULL),
(93, 'Pacific Aura EDP', NULL, 7, 5, NULL, 1999.00, 8, 'images\\Aura.jpg', 'Male', NULL),
(94, 'Pacific Aura EDT', NULL, 8, 5, NULL, 1999.00, 7, 'images\\Aura.jpg', 'Male', NULL),
(95, 'love spell EDT', NULL, 8, 5, NULL, 1399.00, 10, 'images\\Lovespell.jpg', 'Female', NULL),
(96, 'Afternoon Vibe EDP', NULL, 7, 6, NULL, 1499.00, 7, 'images\\AfternoonVibe.jpg', 'Female', NULL),
(97, 'Afternoon Vibe EDT', NULL, 8, 6, NULL, 1499.00, 10, 'images\\AfternoonVibe.jpg', 'Female', NULL),
(98, 'coeur de rose EDP', NULL, 7, 6, NULL, 2099.00, 9, 'images\\CoeurDeRose.jpg', 'Female', NULL),
(99, 'coeur de rose EDT', NULL, 8, 6, NULL, 2099.00, 10, 'images\\CoeurDeRose.jpg', 'Female', NULL),
(100, 'sun set EDP', NULL, 7, 6, NULL, 2099.00, 9, 'images\\Sunset.jpg', 'Female', NULL),
(101, 'sun set EDT', NULL, 8, 6, NULL, 2099.00, 10, 'images\\Sunset.jpg', 'Female', NULL),
(102, 'Knittedpolo - Blue - s', 'blue', 1, 1, 'S', 999.00, 10, 'images\\blue_polo.png', 'Unisex', 1),
(103, 'Knittedpolo - Blue - m', 'blue', 1, 1, 'M', 999.00, 10, 'images\\blue_polo.png', 'Unisex', 1),
(104, 'Knittedpolo - Blue - l', 'blue', 1, 1, 'L', 999.00, 10, 'images\\blue_polo.png', 'Unisex', 1),
(105, 'Knittedpolo - Blue - xl', 'blue', 1, 1, 'XL', 999.00, 7, 'images\\blue_polo.png', 'Unisex', 1),
(106, 'Knittedpolo - Green - xl', 'green', 1, 1, 'XL', 999.00, 9, 'images\\green_polo.png', 'Unisex', 1),
(107, 'Knittedpolo - Green - l', 'green', 1, 1, 'L', 999.00, 10, 'images\\green_polo.png', 'Unisex', 1),
(108, 'Knittedpolo - Green - m', 'green', 1, 1, 'M', 999.00, 10, 'images\\green_polo.png', 'Unisex', 1),
(109, 'Knittedpolo - Green - s', 'green', 1, 1, 'S', 999.00, 10, 'images\\green_polo.png', 'Unisex', 1),
(110, 'Knittedpolo - Red - s', 'red', 1, 1, 'S', 999.00, 10, 'images\\red_polo.png', 'Unisex', 1),
(111, 'Knittedpolo - Red - m', 'red', 1, 1, 'M', 999.00, 10, 'images\\red_polo.png', 'Unisex', 1),
(112, 'Knittedpolo - Red - l', 'red', 1, 1, 'L', 999.00, 10, 'images\\red_polo.png', 'Unisex', 1),
(113, 'Knittedpolo - Red - xl', 'red', 1, 1, 'XL', 999.00, 10, 'images\\red_polo.png', 'Unisex', 1);

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

CREATE TABLE `suppliers` (
  `supplier_id` int(11) NOT NULL,
  `supplier_name` varchar(100) NOT NULL,
  `contact_person` varchar(100) DEFAULT NULL,
  `contact_number` varchar(20) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`supplier_id`, `supplier_name`, `contact_person`, `contact_number`, `address`) VALUES
(1, 'TrendWear Inc.', 'Anna Cruz', '09171234567', 'Unit 201, Fashion Tower, Makati City'),
(2, 'Urban Threads Co.', 'Mike Santos', '09281234567', '3rd Floor, Textile Hub, Quezon City'),
(3, 'MetroStyle Apparel', 'Jane dela Cruz', '09391234567', '8th Ave, Taguig City'),
(4, 'Scentify Distributors', 'Carlos Ramirez', '09181239876', 'Blk 4 Lot 22, Aroma St., Pasig City'),
(5, 'Fragrance World', 'Ella Gomez', '09292234567', 'Perfume Lane, Ortigas Center'),
(6, 'Aromatique Corp.', 'Leo Fernandez', '09452236789', 'Lot 6, Essence Village, San Juan City');

-- --------------------------------------------------------

--
-- Table structure for table `supply_logs`
--

CREATE TABLE `supply_logs` (
  `supply_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `supplier_id` int(11) NOT NULL,
  `quantity_added` int(11) NOT NULL,
  `supply_date` datetime DEFAULT current_timestamp(),
  `remarks` text DEFAULT NULL,
  `supplier_price` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `supply_logs`
--

INSERT INTO `supply_logs` (`supply_id`, `product_id`, `supplier_id`, `quantity_added`, `supply_date`, `remarks`, `supplier_price`) VALUES
(1, 1, 1, 10, '2025-07-23 11:01:12', 'added first stocs', 499.00),
(2, 2, 1, 10, '2025-07-23 11:01:21', 'added first stocs', 499.00),
(3, 3, 1, 10, '2025-07-23 11:01:43', 'added first stocs', 499.00),
(4, 4, 1, 10, '2025-07-23 11:01:49', 'added first stocs', 499.00),
(5, 5, 1, 10, '2025-07-23 11:02:01', 'added first stocs', 499.00),
(6, 6, 1, 10, '2025-07-23 11:02:06', 'added first stocs', 499.00),
(7, 7, 1, 10, '2025-07-23 11:02:14', 'added first stocs', 499.00),
(8, 8, 1, 10, '2025-07-23 11:02:19', 'added first stocs', 499.00),
(9, 9, 1, 10, '2025-07-23 11:02:42', 'added first stocs', 499.00),
(10, 10, 1, 10, '2025-07-23 11:02:47', 'added first stocs', 499.00),
(11, 11, 1, 10, '2025-07-23 11:02:52', 'added first stocs', 499.00),
(12, 12, 1, 10, '2025-07-23 11:03:00', 'added first stocs', 499.00),
(13, 13, 1, 10, '2025-07-23 11:03:07', 'added first stocs', 499.00),
(14, 14, 1, 10, '2025-07-23 11:03:13', 'added first stocs', 499.00),
(15, 15, 1, 10, '2025-07-23 11:03:21', 'added first stocs', 499.00),
(16, 16, 1, 10, '2025-07-23 11:03:26', 'added first stocs', 499.00),
(17, 17, 1, 10, '2025-07-23 11:03:37', 'added first stocs', 499.00),
(18, 18, 1, 10, '2025-07-23 11:03:41', 'added first stocs', 499.00),
(19, 19, 1, 10, '2025-07-23 11:03:48', 'added first stocs', 499.00),
(20, 20, 1, 10, '2025-07-23 11:03:54', 'added first stocs', 499.00),
(21, 21, 3, 10, '2025-07-23 11:05:02', 'first productstocks', 399.00),
(22, 22, 3, 10, '2025-07-23 11:05:06', 'first productstocks', 399.00),
(23, 23, 3, 10, '2025-07-23 11:05:12', 'first productstocks', 399.00),
(24, 24, 3, 10, '2025-07-23 11:05:18', 'first productstocks', 399.00),
(25, 25, 3, 10, '2025-07-23 11:05:30', 'first productstocks', 399.00),
(26, 26, 3, 10, '2025-07-23 11:05:36', 'first productstocks', 399.00),
(27, 27, 3, 10, '2025-07-23 11:05:47', 'first productstocks', 399.00),
(28, 28, 3, 10, '2025-07-23 11:05:51', 'first productstocks', 399.00),
(29, 29, 3, 10, '2025-07-23 11:06:00', 'first productstocks', 399.00),
(30, 30, 3, 10, '2025-07-23 11:06:06', 'first productstocks', 399.00),
(31, 31, 3, 10, '2025-07-23 11:06:14', 'first productstocks', 399.00),
(32, 32, 3, 10, '2025-07-23 11:06:21', 'first productstocks', 399.00),
(33, 33, 3, 10, '2025-07-23 11:06:27', 'first productstocks', 399.00),
(34, 34, 3, 10, '2025-07-23 11:06:31', 'first productstocks', 399.00),
(35, 35, 3, 10, '2025-07-23 11:06:36', 'first productstocks', 399.00),
(36, 36, 3, 10, '2025-07-23 11:06:42', 'first productstocks', 399.00),
(37, 37, 2, 10, '2025-07-23 11:08:36', 'hoodie initial sotcks', 899.00),
(38, 38, 2, 10, '2025-07-23 11:08:40', 'hoodie initial sotcks', 899.00),
(39, 39, 2, 10, '2025-07-23 11:08:45', 'hoodie initial sotcks', 899.00),
(40, 40, 2, 10, '2025-07-23 11:08:50', 'hoodie initial sotcks', 899.00),
(41, 41, 2, 10, '2025-07-23 11:08:55', 'hoodie initial sotcks', 899.00),
(42, 42, 2, 10, '2025-07-23 11:09:09', 'hoodie initial sotcks', 899.00),
(43, 43, 2, 10, '2025-07-23 11:09:14', 'hoodie initial sotcks', 899.00),
(44, 44, 2, 10, '2025-07-23 11:09:18', 'hoodie initial sotcks', 899.00),
(45, 45, 2, 10, '2025-07-23 11:09:24', 'hoodie initial sotcks', 899.00),
(46, 46, 2, 10, '2025-07-23 11:09:30', 'hoodie initial sotcks', 899.00),
(47, 47, 2, 10, '2025-07-23 11:09:36', 'hoodie initial sotcks', 899.00),
(48, 48, 2, 10, '2025-07-23 11:09:41', 'hoodie initial sotcks', 899.00),
(49, 49, 2, 10, '2025-07-23 11:09:46', 'hoodie initial sotcks', 899.00),
(50, 50, 2, 10, '2025-07-23 11:09:51', 'hoodie initial sotcks', 899.00),
(51, 51, 2, 10, '2025-07-23 11:09:55', 'hoodie initial sotcks', 899.00),
(52, 52, 2, 10, '2025-07-23 11:10:03', 'hoodie initial sotcks', 899.00),
(53, 53, 2, 10, '2025-07-23 11:10:08', 'hoodie initial sotcks', 899.00),
(54, 54, 2, 10, '2025-07-23 11:10:12', 'hoodie initial sotcks', 899.00),
(55, 55, 2, 10, '2025-07-23 11:10:18', 'hoodie initial sotcks', 899.00),
(56, 56, 2, 10, '2025-07-23 11:10:26', 'hoodie initial sotcks', 899.00),
(57, 57, 1, 10, '2025-07-23 11:11:32', 'initial stock swetpants', 500.00),
(58, 58, 1, 10, '2025-07-23 11:11:36', 'initial stock swetpants', 500.00),
(59, 59, 1, 10, '2025-07-23 11:11:47', 'initial stock swetpants', 500.00),
(60, 60, 1, 10, '2025-07-23 11:11:52', 'initial stock swetpants', 500.00),
(61, 61, 1, 10, '2025-07-23 11:12:00', 'initial stock swetpants', 500.00),
(62, 62, 1, 10, '2025-07-23 11:12:03', 'initial stock swetpants', 500.00),
(63, 63, 1, 10, '2025-07-23 11:12:07', 'initial stock swetpants', 500.00),
(64, 64, 1, 10, '2025-07-23 11:12:13', 'initial stock swetpants', 500.00),
(65, 65, 1, 10, '2025-07-23 11:12:21', 'initial stock swetpants', 500.00),
(66, 66, 1, 10, '2025-07-23 11:12:25', 'initial stock swetpants', 500.00),
(67, 67, 1, 10, '2025-07-23 11:12:29', 'initial stock swetpants', 500.00),
(68, 68, 1, 10, '2025-07-23 11:12:35', 'initial stock swetpants', 500.00),
(69, 85, 4, 10, '2025-07-23 22:56:58', 'dream perf initial stock', 1000.00),
(70, 86, 4, 10, '2025-07-23 22:58:14', 'initial stock lovespell', 1000.00),
(71, 87, 5, 10, '2025-07-24 00:26:35', 'origin initial sotcks', 1600.00),
(72, 88, 5, 10, '2025-07-24 00:26:49', 'origin initial sotcks', 1600.00),
(74, 90, 4, 10, '2025-07-24 00:31:47', 'initialstockdream edt', 1299.00),
(75, 91, 4, 10, '2025-07-24 00:33:08', 'initialsotkc linfinite', 1500.00),
(76, 92, 4, 10, '2025-07-24 00:33:19', 'initialsotkc linfinite', 1500.00),
(77, 93, 5, 10, '2025-07-24 00:33:58', 'initialsotkc linfinite', 1800.00),
(78, 94, 5, 10, '2025-07-24 00:34:08', 'initialsotkc linfinite', 1800.00),
(79, 95, 5, 10, '2025-07-24 00:38:35', 'initial sotck love spell edt', 1000.00),
(80, 96, 6, 10, '2025-07-24 00:39:20', 'initial sotck afv edp', 1000.00),
(81, 97, 6, 10, '2025-07-24 00:39:29', 'initial sotck afv edt', 1000.00),
(82, 98, 6, 10, '2025-07-24 00:40:15', 'initial sotck cdr edp', 1800.00),
(83, 99, 6, 10, '2025-07-24 00:40:26', 'initial sotck cdr edt', 1800.00),
(84, 100, 6, 10, '2025-07-24 00:41:16', 'initial sotck sunset edp', 1800.00),
(85, 101, 6, 10, '2025-07-24 00:41:29', 'initial sotck sunset edp', 1800.00),
(86, 20, 1, 10, '2025-07-24 12:37:31', 'added product swblackxl', 499.00),
(87, 102, 1, 10, '2025-07-24 15:05:09', 'initial stocks knitted polo', 800.00),
(88, 103, 1, 10, '2025-07-24 15:05:18', 'initial stocks knitted polo', 800.00),
(89, 104, 1, 10, '2025-07-24 15:05:26', 'initial stocks knitted polo', 800.00),
(90, 105, 1, 10, '2025-07-24 15:05:32', 'initial stocks knitted polo', 800.00),
(91, 106, 1, 10, '2025-07-24 15:05:44', 'initial stocks knitted polo', 800.00),
(92, 107, 1, 10, '2025-07-24 15:05:49', 'initial stocks knitted polo', 800.00),
(93, 108, 1, 10, '2025-07-24 15:05:55', 'initial stocks knitted polo', 800.00),
(94, 109, 1, 10, '2025-07-24 15:06:01', 'initial stocks knitted polo', 800.00),
(95, 110, 1, 10, '2025-07-24 15:06:09', 'initial stocks knitted polo', 800.00),
(96, 111, 1, 10, '2025-07-24 15:06:15', 'initial stocks knitted polo', 800.00),
(97, 112, 1, 10, '2025-07-24 15:06:24', 'initial stocks knitted polo', 800.00),
(98, 113, 1, 10, '2025-07-24 15:06:30', 'initial stocks knitted polo', 800.00);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`) VALUES
(1, 'elixqc', '7661f83e32e9b6467f2bb50619049fd8951c266665967ebb678a10d520a36de1'),
(2, 'admin1', '25f43b1486ad95a1398e3eeb3d83bc4010015fcc9bedb35b432e00298d5021f7');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `brands`
--
ALTER TABLE `brands`
  ADD PRIMARY KEY (`brand_id`),
  ADD KEY `supplier_id` (`supplier_id`);

--
-- Indexes for table `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`customer_id`,`product_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `notifications`
--
ALTER TABLE `notifications`
  ADD PRIMARY KEY (`notification_id`),
  ADD KEY `order_id` (`order_id`),
  ADD KEY `fk_customer` (`customer_id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `fk_order_customer` (`customer_id`);

--
-- Indexes for table `order_details`
--
ALTER TABLE `order_details`
  ADD PRIMARY KEY (`order_detail_id`),
  ADD KEY `fk_detail_order` (`order_id`),
  ADD KEY `fk_detail_product` (`product_id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `fk_product_category` (`category_id`),
  ADD KEY `fk_product_supplier` (`supplier_id`),
  ADD KEY `fk_brand` (`brand_id`);

--
-- Indexes for table `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`supplier_id`);

--
-- Indexes for table `supply_logs`
--
ALTER TABLE `supply_logs`
  ADD PRIMARY KEY (`supply_id`),
  ADD KEY `fk_supply_product` (`product_id`),
  ADD KEY `fk_supply_supplier` (`supplier_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `brands`
--
ALTER TABLE `brands`
  MODIFY `brand_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `notifications`
--
ALTER TABLE `notifications`
  MODIFY `notification_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `order_details`
--
ALTER TABLE `order_details`
  MODIFY `order_detail_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=114;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `supply_logs`
--
ALTER TABLE `supply_logs`
  MODIFY `supply_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=99;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `brands`
--
ALTER TABLE `brands`
  ADD CONSTRAINT `brands_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`);

--
-- Constraints for table `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `cart_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `cart_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE;

--
-- Constraints for table `notifications`
--
ALTER TABLE `notifications`
  ADD CONSTRAINT `fk_customer` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `notifications_ibfk_2` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE;

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `fk_order_customer` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE CASCADE;

--
-- Constraints for table `order_details`
--
ALTER TABLE `order_details`
  ADD CONSTRAINT `fk_detail_order` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_detail_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE;

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_brand` FOREIGN KEY (`brand_id`) REFERENCES `brands` (`brand_id`),
  ADD CONSTRAINT `fk_product_category` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`) ON DELETE SET NULL,
  ADD CONSTRAINT `fk_product_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
