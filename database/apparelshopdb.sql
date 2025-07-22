-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 22, 2025 at 06:07 AM
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

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`order_id`, `customer_id`, `order_date`, `order_status`) VALUES
(1, 2, '2025-07-22 12:03:41', 'Pending');

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
(1, 1, 16, 2, 599.00),
(2, 1, 33, 1, 599.00);

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
  `brand_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `color`, `category_id`, `supplier_id`, `size`, `price`, `stock_quantity`, `image_path`, `brand_id`) VALUES
(1, 'Sweatshirt - Black - s', 'black', 2, 1, 'S', 599.00, 50, 'images\\black_swsh.png', 1),
(2, 'Sweatshirt - Black - m', 'black', 2, 1, 'M', 599.00, 10, 'images\\black_swsh.png', 1),
(3, 'Sweatshirt - Black - l', 'black', 2, 1, 'L', 599.00, 10, 'images\\black_swsh.png', 1),
(4, 'Sweatshirt - Black - xl', 'black', 2, 1, 'XL', 599.00, 10, 'images\\black_swsh.png', 1),
(5, 'Sweatshirt - Gray - s', 'gray', 2, 1, 'S', 599.00, 10, 'images\\gray_swsh.png', 1),
(6, 'Sweatshirt - Gray - m', 'gray', 2, 1, 'M', 599.00, 10, 'images\\gray_swsh.png', 1),
(7, 'Sweatshirt - Gray - l', 'gray', 2, 1, 'L', 599.00, 10, 'images\\gray_swsh.png', 1),
(8, 'Sweatshirt - Gray - xl', 'gray', 2, 1, 'XL', 599.00, 10, 'images\\gray_swsh.png', 1),
(9, 'Sweatshirt - Pink - s', 'pink', 2, 1, 'S', 599.00, 10, 'images\\pink_swsh.png', 1),
(10, 'Sweatshirt - Pink - m', 'pink', 2, 1, 'M', 599.00, 10, 'images\\pink_swsh.png', 1),
(11, 'Sweatshirt - Pink - l', 'pink', 2, 1, 'L', 599.00, 10, 'images\\pink_swsh.png', 1),
(12, 'Sweatshirt - Pink - xl', 'pink', 2, 1, 'XL', 599.00, 10, 'images\\pink_swsh.png', 1),
(13, 'Sweatshirt - Yellow - s', 'yellow', 2, 1, 'S', 599.00, 10, 'images\\yellow_swsh.png', 1),
(14, 'Sweatshirt - Yellow - m', 'yellow', 2, 1, 'M', 599.00, 10, 'images\\yellow_swsh.png', 1),
(15, 'Sweatshirt - Yellow - l', 'yellow', 2, 1, 'L', 599.00, 10, 'images\\yellow_swsh.png', 1),
(16, 'Sweatshirt - Yellow - xl', 'yellow', 2, 1, 'XL', 599.00, 10, 'images\\yellow_swsh.png', 1),
(17, 'Sweatshirt - White - xl', 'white', 2, 1, 'XL', 599.00, 10, 'images\\white_swsh.png', 1),
(18, 'Sweatshirt - White - l', 'white', 2, 1, 'L', 599.00, 10, 'images\\white_swsh.png', 1),
(19, 'Sweatshirt - White - m', 'white', 2, 1, 'M', 599.00, 10, 'images\\white_swsh.png', 1),
(20, 'Sweatshirt - White - s', 'white', 2, 1, 'S', 599.00, 10, 'images\\white_swsh.png', 1),
(21, 'T-shirt - Green - s', 'green', 1, 2, 'S', 599.00, 10, 'images\\green_shirt1.png', 3),
(22, 'T-shirt - Green - m', 'green', 1, 2, 'M', 599.00, 10, 'images\\green_shirt1.png', 3),
(23, 'T-shirt - Green - l', 'green', 1, 2, 'L', 599.00, 10, 'images\\green_shirt1.png', 3),
(24, 'T-shirt - Green - xl', 'green', 1, 2, 'XL', 599.00, 10, 'images\\green_shirt1.png', 3),
(25, 'T-shirt - White - s', 'white', 1, 2, 'S', 599.00, 10, 'images\\white_shirt1.png', 3),
(26, 'T-shirt - White - m', 'white', 1, 2, 'M', 599.00, 10, 'images\\white_shirt1.png', 3),
(27, 'T-shirt - White - l', 'white', 1, 2, 'L', 599.00, 10, 'images\\white_shirt1.png', 3),
(28, 'T-shirt - White - xl', 'white', 1, 2, 'XL', 599.00, 10, 'images\\white_shirt1.png', 3),
(29, 'T-shirt - Brown - s', 'brown', 1, 2, 'S', 599.00, 10, 'images\\brown_shirt1.png', 1),
(30, 'T-shirt - Brown - m', 'brown', 1, 2, 'M', 599.00, 10, 'images\\brown_shirt1.png', 1),
(31, 'T-shirt - Brown - l', 'brown', 1, 2, 'L', 599.00, 10, 'images\\brown_shirt1.png', 1),
(32, 'T-shirt - Brown - xl', 'brown', 1, 2, 'XL', 599.00, 10, 'images\\brown_shirt1.png', 1),
(33, 'T-shirt - Blue - xl', 'blue', 1, 2, 'XL', 599.00, 10, 'images\\blue_shirt1.png', 1),
(34, 'T-shirt - Blue - l', 'blue', 1, 2, 'L', 599.00, 10, 'images\\blue_shirt1.png', 1),
(35, 'T-shirt - Blue - m', 'blue', 1, 2, 'M', 599.00, 10, 'images\\blue_shirt1.png', 1),
(36, 'T-shirt - Blue - s', 'blue', 1, 2, 'S', 599.00, 10, 'images\\blue_shirt1.png', 1),
(37, 'Oversizedhoodie - Yellow - s', 'yellow', 4, 3, 'S', 999.00, 10, 'images\\yellow_hoodie.png', 2),
(38, 'Oversizedhoodie - Yellow - m', 'yellow', 4, 3, 'M', 999.00, 10, 'images\\yellow_hoodie.png', 2),
(39, 'Oversizedhoodie - Yellow - l', 'yellow', 4, 3, 'L', 999.00, 10, 'images\\yellow_hoodie.png', 2),
(40, 'Oversizedhoodie - Yellow - xl', 'yellow', 4, 3, 'XL', 999.00, 10, 'images\\yellow_hoodie.png', 2),
(41, 'Oversizedhoodie - Red - xl', 'red', 4, 3, 'XL', 999.00, 10, 'images\\red_hoodie.png', 2),
(42, 'Oversizedhoodie - Red - l', 'red', 4, 3, 'L', 999.00, 10, 'images\\red_hoodie.png', 2),
(43, 'Oversizedhoodie - Red - m', 'red', 4, 3, 'M', 999.00, 10, 'images\\red_hoodie.png', 2),
(44, 'Oversizedhoodie - Red - s', 'red', 4, 3, 'S', 999.00, 10, 'images\\red_hoodie.png', 2),
(45, 'Oversizedhoodie - Blue - s', 'blue', 4, 3, 'S', 999.00, 10, 'images\\blue_hoodie.png', 2),
(46, 'Oversizedhoodie - Blue - m', 'blue', 4, 3, 'M', 999.00, 10, 'images\\blue_hoodie.png', 2),
(47, 'Oversizedhoodie - Blue - l', 'blue', 4, 3, 'L', 999.00, 10, 'images\\blue_hoodie.png', 2),
(48, 'Oversizedhoodie - Blue - xl', 'blue', 4, 3, 'XL', 999.00, 10, 'images\\blue_hoodie.png', 2),
(49, 'Oversizedhoodie - Pink - xl', 'pink', 4, 3, 'XL', 999.00, 10, 'images\\pink_hoodie.png', 2),
(50, 'Oversizedhoodie - Pink - l', 'pink', 4, 3, 'L', 999.00, 10, 'images\\pink_hoodie.png', 2),
(51, 'Oversizedhoodie - Pink - m', 'pink', 4, 3, 'M', 999.00, 10, 'images\\pink_hoodie.png', 2),
(52, 'Oversizedhoodie - Pink - s', 'pink', 4, 3, 'S', 999.00, 10, 'images\\pink_hoodie.png', 2),
(53, 'Sweatpants - White - s', 'white', 3, 1, 'S', 799.00, 10, 'images\\white_sweatpants.png', 1),
(54, 'Sweatpants - White - m', 'white', 3, 1, 'M', 799.00, 10, 'images\\white_sweatpants.png', 1),
(55, 'Sweatpants - White - l', 'white', 3, 1, 'L', 799.00, 10, 'images\\white_sweatpants.png', 1),
(56, 'Sweatpants - White - xl', 'white', 3, 1, 'XL', 799.00, 10, 'images\\white_sweatpants.png', 1),
(57, 'Sweatpants - Gray - xl', 'gray', 3, 1, 'XL', 799.00, 10, 'images\\gray_Sweatpants.png', 1),
(58, 'Sweatpants - Gray - l', 'gray', 3, 1, 'L', 799.00, 10, 'images\\gray_Sweatpants.png', 1),
(59, 'Sweatpants - Gray - m', 'gray', 3, 1, 'M', 799.00, 10, 'images\\gray_Sweatpants.png', 1),
(60, 'Sweatpants - Gray - s', 'gray', 3, 1, 'S', 799.00, 10, 'images\\gray_Sweatpants.png', 1),
(61, 'Sweatpants - Black - s', 'black', 3, 1, 'S', 799.00, 10, 'images\\black_Sweatpants.png', 1),
(62, 'Sweatpants - Black - m', 'black', 3, 1, 'M', 799.00, 10, 'images\\black_Sweatpants.png', 1),
(63, 'Sweatpants - Black - l', 'black', 3, 1, 'L', 799.00, 10, 'images\\black_Sweatpants.png', 1),
(64, 'Sweatpants - Black - xl', 'black', 3, 1, 'XL', 799.00, 10, 'images\\black_Sweatpants.png', 1);

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
(2, 1, 1, 10, '2025-07-21 16:27:08', 'added sweatshirt small black 10pcs', 10.00),
(3, 1, 1, 0, '2025-07-21 21:18:14', '', 499.00);

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
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `order_details`
--
ALTER TABLE `order_details`
  MODIFY `order_detail_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=65;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `supply_logs`
--
ALTER TABLE `supply_logs`
  MODIFY `supply_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

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
