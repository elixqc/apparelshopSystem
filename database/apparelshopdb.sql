-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 20, 2025 at 06:59 AM
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

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`customer_id`, `product_id`, `quantity`, `size`, `date_added`) VALUES
(2, 100, 5, 'XL', '2025-07-20 12:15:36');

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
(8, 'Eau de Toilette'),
(9, 'Cologne'),
(10, 'Body Mist'),
(11, 'Perfume Oil'),
(12, 'Fragrance Set');

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
(2, 'nico', '09392891165', '291', 'nico@gmail.com', 'b18aaa6c6b929b866051b69a785a6cdce5bdd564d41be247c7d5ef7c2e2e2271'),
(3, 'joseph', '0939412331', 'taguig city', 'joseph@gmail.com', '7ee8118150e0ce023742beba6f10bf23aabbf0bc2c182f36fd1a6753cd21b4c6');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT current_timestamp(),
  `order_status` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `order_details`
--

CREATE TABLE `order_details` (
  `order_detail_id` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  `fragrance_type` varchar(50) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) NOT NULL DEFAULT 0,
  `image_path` varchar(255) DEFAULT NULL,
  `brand_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `color`, `category_id`, `supplier_id`, `size`, `fragrance_type`, `price`, `stock_quantity`, `image_path`, `brand_id`) VALUES
(1, 'Sweatshirt - Black - S', 'Black', 2, 1, 'S', NULL, 599.00, 10, 'images/black_swsh.png', 1),
(2, 'Sweatshirt - Black - M', 'Black', 2, 1, 'M', NULL, 599.00, 10, 'images/black_swsh.png', 1),
(3, 'Sweatshirt - Black - L', 'Black', 2, 1, 'L', NULL, 599.00, 10, 'images/black_swsh.png', 1),
(4, 'Sweatshirt - Black - XL', 'Black', 2, 1, 'XL', NULL, 599.00, 10, 'images/black_swsh.png', 1),
(5, 'Sweatshirt - White - S', 'White', 2, 1, 'S', NULL, 599.00, 10, 'images/white_swsh.png', 1),
(6, 'Sweatshirt - White - M', 'White', 2, 1, 'M', NULL, 599.00, 10, 'images/white_swsh.png', 1),
(7, 'Sweatshirt - White - L', 'White', 2, 1, 'L', NULL, 599.00, 10, 'images/white_swsh.png', 1),
(8, 'Sweatshirt - White - XL', 'White', 2, 1, 'XL', NULL, 599.00, 10, 'images/white_swsh.png', 1),
(9, 'Sweatshirt - Gray - S', 'Gray', 1, 1, 'S', NULL, 599.00, 10, 'images/gray_swsh.png', 1),
(10, 'Sweatshirt - Gray - M', 'Gray', 1, 1, 'M', NULL, 599.00, 10, 'images/gray_swsh.png', 1),
(11, 'Sweatshirt - Gray - L', 'Gray', 1, 1, 'L', NULL, 599.00, 10, 'images/gray_swsh.png', 1),
(12, 'Sweatshirt - Gray - XL', 'Gray', 1, 1, 'XL', NULL, 599.00, 10, 'images/gray_swsh.png', 1),
(13, 'Sweatshirt - Yellow - S', 'Yellow', 2, 1, 'S', NULL, 599.00, 10, 'images/yellow_swsh.png', 1),
(14, 'Sweatshirt - Yellow - M', 'Yellow', 2, 1, 'M', NULL, 599.00, 10, 'images/yellow_swsh.png', 1),
(15, 'Sweatshirt - Yellow - L', 'Yellow', 2, 1, 'L', NULL, 599.00, 10, 'images/yellow_swsh.png', 1),
(16, 'Sweatshirt - Yellow - XL', 'Yellow', 2, 1, 'XL', NULL, 599.00, 10, 'images/yellow_swsh.png', 1),
(17, 'Sweatshirt - Pink - S', 'Pink', 2, 1, 'S', NULL, 599.00, 10, 'images/pink_swsh.png', 1),
(18, 'Sweatshirt - Pink - M', 'Pink', 2, 1, 'M', NULL, 599.00, 10, 'images/pink_swsh.png', 1),
(19, 'Sweatshirt - Pink - L', 'Pink', 2, 1, 'L', NULL, 599.00, 10, 'images/pink_swsh.png', 1),
(20, 'Sweatshirt - Pink - XL', 'Pink', 2, 1, 'XL', NULL, 599.00, 10, 'images/pink_swsh.png', 1),
(81, 'overSizedHoodie - Red - S', 'Red', 4, 3, 'S', NULL, 999.00, 10, 'images/red_hoodie.png', 2),
(82, 'overSizedHoodie - Red - M', 'Red', 4, 3, 'M', NULL, 999.00, 10, 'images/red_hoodie.png', 2),
(83, 'overSizedHoodie - Red - L', 'Red', 4, 3, 'L', NULL, 999.00, 10, 'images/red_hoodie.png', 2),
(84, 'overSizedHoodie - Red - XL', 'Red', 4, 3, 'XL', NULL, 999.00, 10, 'images/red_hoodie.png', 2),
(85, 'overSizedHoodie - Blue - S', 'Blue', 4, 3, 'S', NULL, 999.00, 10, 'images/blue_hoodie.png', 2),
(86, 'overSizedHoodie - Blue - M', 'Blue', 4, 3, 'M', NULL, 999.00, 10, 'images/blue_hoodie.png', 2),
(87, 'overSizedHoodie - Blue - L', 'Blue', 4, 3, 'L', NULL, 999.00, 10, 'images/blue_hoodie.png', 2),
(88, 'overSizedHoodie - Blue - XL', 'Blue', 4, 3, 'XL', NULL, 999.00, 10, 'images/blue_hoodie.png', 2),
(89, 'overSizedHoodie - Pink - S', 'Pink', 4, 3, 'S', NULL, 999.00, 10, 'images/pink_hoodie.png', 2),
(90, 'overSizedHoodie - Pink - M', 'Pink', 4, 3, 'M', NULL, 999.00, 10, 'images/pink_hoodie.png', 2),
(91, 'overSizedHoodie - Pink - L', 'Pink', 4, 3, 'L', NULL, 999.00, 10, 'images/pink_hoodie.png', 2),
(92, 'overSizedHoodie - Pink - XL', 'Pink', 4, 3, 'XL', NULL, 999.00, 10, 'images/pink_hoodie.png', 2),
(97, 'overSizedHoodie - Yellow - S', 'Yellow', 4, 3, 'S', NULL, 999.00, 10, 'images/yellow_hoodie.png', 2),
(98, 'overSizedHoodie - Yellow - M', 'Yellow', 4, 3, 'M', NULL, 999.00, 10, 'images/yellow_hoodie.png', 2),
(99, 'overSizedHoodie - Yellow - L', 'Yellow', 4, 3, 'L', NULL, 999.00, 10, 'images/yellow_hoodie.png', 2),
(100, 'overSizedHoodie - Yellow - XL', 'Yellow', 4, 3, 'XL', NULL, 999.00, 10, 'images/yellow_hoodie.png', 2),
(101, 'T-shirt - Blue - S', 'Blue', 1, 2, 'S', NULL, 499.00, 10, 'images/blue_shirt1.png', 3),
(102, 'T-shirt - Blue - M', 'Blue', 1, 2, 'M', NULL, 499.00, 10, 'images/blue_shirt1.png', 3),
(103, 'T-shirt - Blue - L', 'Blue', 1, 2, 'L', NULL, 499.00, 10, 'images/blue_shirt1.png', 3),
(104, 'T-shirt - Blue - XL', 'Blue', 1, 2, 'XL', NULL, 499.00, 10, 'images/blue_shirt1.png', 3),
(105, 'T-shirt - Green - S', 'Green', 1, 2, 'S', NULL, 499.00, 10, 'images/green_shirt1.png', 3),
(106, 'T-shirt - Green - M', 'Green', 1, 2, 'M', NULL, 499.00, 10, 'images/green_shirt1.png', 3),
(107, 'T-shirt - Green - L', 'Green', 1, 2, 'L', NULL, 499.00, 10, 'images/green_shirt1.png', 3),
(108, 'T-shirt - Green - XL', 'Green', 1, 2, 'XL', NULL, 499.00, 10, 'images/green_shirt1.png', 3),
(109, 'T-shirt - Brown - S', 'Brown', 4, 2, 'S', NULL, 499.00, 10, 'images/brown_shirt1.png', 3),
(110, 'T-shirt - Brown - M', 'Brown', 4, 2, 'M', NULL, 499.00, 10, 'images/brown_shirt1.png', 3),
(111, 'T-shirt - Brown - L', 'Brown', 4, 2, 'L', NULL, 499.00, 10, 'images/brown_shirt1.png', 3),
(112, 'T-shirt - Brown - XL', 'Brown', 4, 2, 'XL', NULL, 499.00, 10, 'images/brown_shirt1.png', 3),
(113, 'T-shirt - White - S', 'White', 1, 2, 'S', NULL, 499.00, 10, 'images/white_shirt1.png', 3),
(114, 'T-shirt - White - M', 'White', 1, 2, 'M', NULL, 499.00, 10, 'images/white_shirt1.png', 3),
(115, 'T-shirt - White - L', 'White', 1, 2, 'L', NULL, 499.00, 10, 'images/white_shirt1.png', 3),
(116, 'T-shirt - White - XL', 'White', 1, 2, 'XL', NULL, 499.00, 10, 'images/white_shirt1.png', 3),
(129, 'Sweatpants - Gray - S', 'Gray', 2, 1, 'S', NULL, 599.00, 10, 'images/gray_Sweatpants.png', 1),
(130, 'Sweatpants - Gray - M', 'Gray', 2, 1, 'M', NULL, 599.00, 10, 'images/gray_Sweatpants.png', 1),
(131, 'Sweatpants - Gray - L', 'Gray', 2, 1, 'L', NULL, 599.00, 10, 'images/gray_Sweatpants.png', 1),
(132, 'Sweatpants - Gray - XL', 'Gray', 2, 1, 'XL', NULL, 599.00, 10, 'images/gray_Sweatpants.png', 1),
(133, 'Sweatpants - White - S', 'White', 2, 1, 'S', NULL, 599.00, 10, 'images/white_sweatpants.png', 1),
(134, 'Sweatpants - White - M', 'White', 2, 1, 'M', NULL, 599.00, 10, 'images/white_sweatpants.png', 1),
(135, 'Sweatpants - White - L', 'White', 2, 1, 'L', NULL, 599.00, 10, 'images/white_sweatpants.png', 1),
(136, 'Sweatpants - White - XL', 'White', 2, 1, 'XL', NULL, 599.00, 10, 'images/white_sweatpants.png', 1),
(137, 'Sweatpants - Black - S', 'Black', 2, 1, 'S', NULL, 599.00, 10, 'images/black_Sweatpants.png', 1),
(138, 'Sweatpants - Black - M', 'Black', 2, 1, 'M', NULL, 599.00, 10, 'images/black_Sweatpants.png', 1),
(139, 'Sweatpants - Black - L', 'Black', 2, 1, 'L', NULL, 599.00, 10, 'images/black_Sweatpants.png', 1),
(140, 'Sweatpants - Black - XL', 'Black', 2, 1, 'XL', NULL, 599.00, 10, 'images/black_Sweatpants.png', 1);

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
(1, 1, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(2, 2, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(3, 3, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(4, 4, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(5, 5, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(6, 6, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(7, 7, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(8, 8, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(9, 9, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(10, 10, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(11, 11, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(12, 12, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(13, 13, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(14, 14, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(15, 15, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(16, 16, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(17, 17, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(18, 18, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(19, 19, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00),
(20, 20, 1, 10, '2025-07-09 15:48:44', 'Initial stock', 499.00);

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
(1, 'elixqc', '7661f83e32e9b6467f2bb50619049fd8951c266665967ebb678a10d520a36de1');

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
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `order_details`
--
ALTER TABLE `order_details`
  MODIFY `order_detail_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=141;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `supply_logs`
--
ALTER TABLE `supply_logs`
  MODIFY `supply_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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

--
-- Constraints for table `supply_logs`
--
ALTER TABLE `supply_logs`
  ADD CONSTRAINT `fk_supply_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_supply_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
