-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 09, 2025 at 04:16 PM
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
-- Table structure for table `cart`
--

CREATE TABLE `cart` (
  `cart_id` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `date_added` datetime DEFAULT current_timestamp(),
  `size` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`cart_id`, `customer_id`, `product_id`, `quantity`, `date_added`, `size`) VALUES
(2, 2, 100, 1, '2025-07-09 20:50:43', 'XL');

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
  `category_id` int(11) DEFAULT NULL,
  `supplier_id` int(11) DEFAULT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `size` varchar(20) DEFAULT NULL,
  `fragrance_type` varchar(50) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock_quantity` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `category_id`, `supplier_id`, `brand`, `size`, `fragrance_type`, `price`, `stock_quantity`) VALUES
(1, 'Sweatshirt - Black - S', 2, 1, 'TrendWear', 'S', NULL, 599.00, 10),
(2, 'Sweatshirt - Black - M', 2, 1, 'TrendWear', 'M', NULL, 599.00, 10),
(3, 'Sweatshirt - Black - L', 2, 1, 'TrendWear', 'L', NULL, 599.00, 10),
(4, 'Sweatshirt - Black - XL', 2, 1, 'TrendWear', 'XL', NULL, 599.00, 10),
(5, 'Sweatshirt - White - S', 2, 1, 'TrendWear', 'S', NULL, 599.00, 10),
(6, 'Sweatshirt - White - M', 2, 1, 'TrendWear', 'M', NULL, 599.00, 10),
(7, 'Sweatshirt - White - L', 2, 1, 'TrendWear', 'L', NULL, 599.00, 10),
(8, 'Sweatshirt - White - XL', 2, 1, 'TrendWear', 'XL', NULL, 599.00, 10),
(9, 'Sweatshirt - Gray - S', 1, 1, 'TrendWear', 'S', NULL, 599.00, 10),
(10, 'Sweatshirt - Gray - M', 1, 1, 'TrendWear', 'M', NULL, 599.00, 10),
(11, 'Sweatshirt - Gray - L', 1, 1, 'TrendWear', 'L', NULL, 599.00, 10),
(12, 'Sweatshirt - Gray - XL', 1, 1, 'TrendWear', 'XL', NULL, 599.00, 10),
(13, 'Sweatshirt - Yellow - S', 2, 1, 'TrendWear', 'S', NULL, 599.00, 10),
(14, 'Sweatshirt - Yellow - M', 2, 1, 'TrendWear', 'M', NULL, 599.00, 10),
(15, 'Sweatshirt - Yellow - L', 2, 1, 'TrendWear', 'L', NULL, 599.00, 10),
(16, 'Sweatshirt - Yellow - XL', 2, 1, 'TrendWear', 'XL', NULL, 599.00, 10),
(17, 'Sweatshirt - Pink - S', 2, 1, 'TrendWear', 'S', NULL, 599.00, 10),
(18, 'Sweatshirt - Pink - M', 2, 1, 'TrendWear', 'M', NULL, 599.00, 10),
(19, 'Sweatshirt - Pink - L', 2, 1, 'TrendWear', 'L', NULL, 599.00, 10),
(20, 'Sweatshirt - Pink - XL', 2, 1, 'TrendWear', 'XL', NULL, 599.00, 10),
(81, 'overSizedHoodie - Red - S', 4, 3, 'Metrostyle', 'S', NULL, 999.00, 10),
(82, 'overSizedHoodie - Red - M', 4, 3, 'Metrostyle', 'M', NULL, 999.00, 10),
(83, 'overSizedHoodie - Red - L', 4, 3, 'Metrostyle', 'L', NULL, 999.00, 10),
(84, 'overSizedHoodie - Red - XL', 4, 3, 'Metrostyle', 'XL', NULL, 999.00, 10),
(85, 'overSizedHoodie - Blue - S', 4, 3, 'Metrostyle', 'S', NULL, 999.00, 10),
(86, 'overSizedHoodie - Blue - M', 4, 3, 'Metrostyle', 'M', NULL, 999.00, 10),
(87, 'overSizedHoodie - Blue - L', 4, 3, 'Metrostyle', 'L', NULL, 999.00, 10),
(88, 'overSizedHoodie - Blue - XL', 4, 3, 'Metrostyle', 'XL', NULL, 999.00, 10),
(89, 'overSizedHoodie - Pink - S', 4, 3, 'Metrostyle', 'S', NULL, 999.00, 10),
(90, 'overSizedHoodie - Pink - M', 4, 3, 'Metrostyle', 'M', NULL, 999.00, 10),
(91, 'overSizedHoodie - Pink - L', 4, 3, 'Metrostyle', 'L', NULL, 999.00, 10),
(92, 'overSizedHoodie - Pink - XL', 4, 3, 'Metrostyle', 'XL', NULL, 999.00, 10),
(97, 'overSizedHoodie - Yellow - S', 4, 3, 'Metrostyle', 'S', NULL, 999.00, 10),
(98, 'overSizedHoodie - Yellow - M', 4, 3, 'Metrostyle', 'M', NULL, 999.00, 10),
(99, 'overSizedHoodie - Yellow - L', 4, 3, 'Metrostyle', 'L', NULL, 999.00, 10),
(100, 'overSizedHoodie - Yellow - XL', 4, 3, 'Metrostyle', 'XL', NULL, 999.00, 10),
(101, 'T-shirt - Blue - S', 1, 2, 'UrbanThreads', 'S', NULL, 499.00, 10),
(102, 'T-shirt - Blue - M', 1, 2, 'UrbanThreads', 'M', NULL, 499.00, 10),
(103, 'T-shirt - Blue - L', 1, 2, 'UrbanThreads', 'L', NULL, 499.00, 10),
(104, 'T-shirt - Blue - XL', 1, 2, 'UrbanThreads', 'XL', NULL, 499.00, 10),
(105, 'T-shirt - Green - S', 1, 2, 'UrbanThreads', 'S', NULL, 499.00, 10),
(106, 'T-shirt - Green - M', 1, 2, 'UrbanThreads', 'M', NULL, 499.00, 10),
(107, 'T-shirt - Green - L', 1, 2, 'UrbanThreads', 'L', NULL, 499.00, 10),
(108, 'T-shirt - Green - XL', 1, 2, 'UrbanThreads', 'XL', NULL, 499.00, 10),
(109, 'T-shirt - Brown - S', 4, 2, 'UrbanThreads', 'S', NULL, 499.00, 10),
(110, 'T-shirt - Brown - M', 4, 2, 'UrbanThreads', 'M', NULL, 499.00, 10),
(111, 'T-shirt - Brown - L', 4, 2, 'UrbanThreads', 'L', NULL, 499.00, 10),
(112, 'T-shirt - Brown - XL', 4, 2, 'UrbanThreads', 'XL', NULL, 499.00, 10),
(113, 'T-shirt - White - S', 1, 2, 'UrbanThreads', 'S', NULL, 499.00, 10),
(114, 'T-shirt - White - M', 1, 2, 'UrbanThreads', 'M', NULL, 499.00, 10),
(115, 'T-shirt - White - L', 1, 2, 'UrbanThreads', 'L', NULL, 499.00, 10),
(116, 'T-shirt - White - XL', 1, 2, 'UrbanThreads', 'XL', NULL, 499.00, 10);

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
-- Indexes for table `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`cart_id`),
  ADD KEY `customer_id` (`customer_id`),
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
  ADD KEY `fk_product_supplier` (`supplier_id`);

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
-- AUTO_INCREMENT for table `cart`
--
ALTER TABLE `cart`
  MODIFY `cart_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

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
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=117;

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
