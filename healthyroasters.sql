-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 17, 2020 at 04:49 AM
-- Server version: 10.1.25-MariaDB
-- PHP Version: 7.1.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `healthyroasters`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_account_credentials`
--

CREATE TABLE `tbl_account_credentials` (
  `user_id` int(10) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `usertype` varchar(10) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_account_credentials`
--

INSERT INTO `tbl_account_credentials` (`user_id`, `username`, `password`, `usertype`, `status`) VALUES
(100001, 'manager', 'masterkey', 'admin', 'inactive'),
(100002, 'cashier', 'cashier', 'user', 'inactive'),
(100003, 'ambi', 'admin123', 'admin', 'inactive'),
(100004, 'nunie', '123admin', 'admin', 'inactive');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_activity_log`
--

CREATE TABLE `tbl_activity_log` (
  `activity_id` int(10) NOT NULL,
  `username` varchar(50) NOT NULL,
  `activity_description` varchar(200) NOT NULL,
  `date` varchar(50) NOT NULL,
  `time` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_activity_log`
--

INSERT INTO `tbl_activity_log` (`activity_id`, `username`, `activity_description`, `date`, `time`) VALUES
(1844, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:12:35 AM'),
(1845, 'cashier', 'Logged out', '06 17 2020', '10:12:42 AM'),
(1846, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:13:27 AM'),
(1847, 'cashier', 'Logged out', '06 17 2020', '10:13:32 AM'),
(1848, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:13:35 AM'),
(1849, 'cashier', 'Logged out', '06 17 2020', '10:13:48 AM'),
(1850, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:14:27 AM'),
(1851, 'cashier', 'Logged out', '06 17 2020', '10:14:36 AM'),
(1852, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:15:56 AM'),
(1853, 'cashier', 'Logged out', '06 17 2020', '10:16:19 AM'),
(1854, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:17:28 AM'),
(1855, 'cashier', 'Logged out', '06 17 2020', '10:19:58 AM'),
(1856, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:20:27 AM'),
(1857, 'cashier', 'Sold an order', '06 17 2020', '10:20:57 AM'),
(1858, 'cashier', 'Logged out', '06 17 2020', '10:21:16 AM'),
(1859, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:22:16 AM'),
(1860, 'cashier', 'Logged out', '06 17 2020', '10:22:39 AM'),
(1861, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:22:58 AM'),
(1862, 'cashier', 'Logged out', '06 17 2020', '10:23:26 AM'),
(1863, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:23:55 AM'),
(1864, 'cashier', 'Logged out', '06 17 2020', '10:24:06 AM'),
(1865, 'Ryan Aristosa', 'Logged in', '06 17 2020', '10:29:51 AM'),
(1866, 'Ryan Aristosa', 'Logged out', '06 17 2020', '10:30:11 AM'),
(1867, 'Ryan Aristosa', 'Logged in', '06 17 2020', '10:30:51 AM'),
(1868, 'Ryan Aristosa', 'Logged out', '06 17 2020', '10:31:12 AM'),
(1869, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:32:43 AM'),
(1870, 'cashier', 'Logged out', '06 17 2020', '10:32:46 AM'),
(1871, 'Ryan Aristosa', 'Logged in', '06 17 2020', '10:32:48 AM'),
(1872, 'Ryan Aristosa', 'Logged out', '06 17 2020', '10:33:29 AM'),
(1873, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:33:43 AM'),
(1874, 'cashier', 'Sold an order', '06 17 2020', '10:33:59 AM'),
(1875, 'cashier', 'Sold an order', '06 17 2020', '10:34:07 AM'),
(1876, 'cashier', 'Logged out', '06 17 2020', '10:34:09 AM'),
(1877, 'Ryan Aristosa', 'Logged in', '06 17 2020', '10:34:23 AM'),
(1878, 'Ryan Aristosa', 'Logged out', '06 17 2020', '10:34:49 AM'),
(1879, 'Ryan Aristosa', 'Logged in', '06 17 2020', '10:35:26 AM'),
(1880, 'Ryan Aristosa', 'Logged out', '06 17 2020', '10:35:45 AM'),
(1881, 'Ryan Aristosa', 'Logged in', '06 17 2020', '10:36:40 AM'),
(1882, 'Ryan Aristosa', 'Logged out', '06 17 2020', '10:36:56 AM'),
(1883, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:43:31 AM'),
(1884, 'cashier ', 'Logged out', '06 17 2020', '10:43:34 AM'),
(1885, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:43:42 AM'),
(1886, 'cashier', 'Sold an order', '06 17 2020', '10:44:25 AM'),
(1887, 'cashier', 'Discounted a SC  patron', '06 17 2020', '10:44:35 AM'),
(1888, 'cashier', 'Logged out', '06 17 2020', '10:44:44 AM'),
(1889, 'Ryan Aristosa', 'Logged in', '06 17 2020', '10:44:48 AM'),
(1890, 'Ryan Aristosa', 'Optimized discount and tax percentage', '06 17 2020', '10:45:01 AM'),
(1891, 'Ryan Aristosa', 'Logged out', '06 17 2020', '10:45:04 AM'),
(1892, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:45:08 AM'),
(1893, 'cashier', 'Discounted a PWD patron', '06 17 2020', '10:45:23 AM'),
(1894, 'cashier', 'Order voided, validated by: ambi ', '06 17 2020', '10:45:33 AM'),
(1895, 'cashier', 'Discounted a SC  patron', '06 17 2020', '10:45:43 AM'),
(1896, 'cashier', 'Order voided, validated by: ambi', '06 17 2020', '10:45:47 AM'),
(1897, 'cashier', '50% Manager Discount by: Ryan Aristosa', '06 17 2020', '10:46:06 AM'),
(1898, 'cashier', 'Order voided, validated by: ambi', '06 17 2020', '10:46:10 AM'),
(1899, 'cashier', 'Discounted using Coupon with 50 % discount', '06 17 2020', '10:46:28 AM'),
(1900, 'cashier', 'Logged out', '06 17 2020', '10:46:32 AM'),
(1901, 'Ryan Aristosa', 'Logged in', '06 17 2020', '10:46:35 AM'),
(1902, 'Ryan Aristosa', 'The information of coupon has been modified', '06 17 2020', '10:46:51 AM'),
(1903, 'Ryan Aristosa', 'Logged out', '06 17 2020', '10:47:24 AM'),
(1904, 'Cashier Cashier', 'Logged in', '06 17 2020', '10:47:28 AM'),
(1905, 'cashier', 'Discounted using Coupon with 30 % discount', '06 17 2020', '10:47:35 AM'),
(1906, 'cashier', 'Logged out', '06 17 2020', '10:47:39 AM'),
(1907, 'Ryan Aristosa', 'Logged in', '06 17 2020', '10:47:42 AM'),
(1908, 'Ryan Aristosa', 'Created asda product item', '06 17 2020', '10:48:21 AM'),
(1909, 'Ryan Aristosa', 'Deleted asda product item', '06 17 2020', '10:48:26 AM'),
(1910, 'Ryan Aristosa', 'Logged out', '06 17 2020', '10:48:48 AM');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_coupon`
--

CREATE TABLE `tbl_coupon` (
  `coupon_ID` varchar(20) NOT NULL,
  `coupon_desc` varchar(100) NOT NULL,
  `coupon_percent` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_coupon`
--

INSERT INTO `tbl_coupon` (`coupon_ID`, `coupon_desc`, `coupon_percent`) VALUES
('012', '30 percent', '30');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_products`
--

CREATE TABLE `tbl_products` (
  `product_id` varchar(10) NOT NULL,
  `product_name` varchar(50) NOT NULL,
  `product_price` varchar(50) NOT NULL,
  `item_type` varchar(10) NOT NULL,
  `status` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_products`
--

INSERT INTO `tbl_products` (`product_id`, `product_name`, `product_price`, `item_type`, `status`) VALUES
('D00001', 'Lemonade Drink', '20.00', 'drinks', 'in-stock'),
('D00002', 'Pineapple Juice', '25.00', 'drinks', 'in-stock'),
('S00001', 'Chicken Salad', '100.00', 'salad', 'in-stock'),
('S00002', 'Rice Salad', '75.00', 'salad', 'in-stock');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_sales_report`
--

CREATE TABLE `tbl_sales_report` (
  `sales_id` int(10) NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  `day` varchar(10) NOT NULL,
  `month` varchar(10) NOT NULL,
  `year` varchar(10) NOT NULL,
  `time` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_sales_report`
--

INSERT INTO `tbl_sales_report` (`sales_id`, `amount`, `day`, `month`, `year`, `time`) VALUES
(108, '260.00', '17', 'June', '2020', '10:20 AM'),
(109, '225.00', '17', 'June', '2020', '10:33 AM'),
(110, '45.00', '17', 'June', '2020', '10:34 AM'),
(111, '100.00', '17', 'June', '2020', '10:44 AM');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_tax_discount`
--

CREATE TABLE `tbl_tax_discount` (
  `percent_id` varchar(10) NOT NULL,
  `sc_discount` varchar(10) NOT NULL,
  `pwd_discount` varchar(10) NOT NULL,
  `vat_percent` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_tax_discount`
--

INSERT INTO `tbl_tax_discount` (`percent_id`, `sc_discount`, `pwd_discount`, `vat_percent`) VALUES
('1', '20', '20', '12');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user_information`
--

CREATE TABLE `tbl_user_information` (
  `user_id` int(10) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `gender` varchar(10) NOT NULL,
  `mobile_no` varchar(20) NOT NULL,
  `tel_no` varchar(20) NOT NULL,
  `email` varchar(30) NOT NULL,
  `address` varchar(100) NOT NULL,
  `birthday` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_user_information`
--

INSERT INTO `tbl_user_information` (`user_id`, `firstname`, `middlename`, `lastname`, `gender`, `mobile_no`, `tel_no`, `email`, `address`, `birthday`) VALUES
(100001, 'Edward Jocel', 'Abuloc', 'Parrucho', 'Male', '09673470882', '4032189', 'parruchoedward@gmail.com', 'Makati City', '08/12/1999'),
(100002, 'Cashier', '-', 'Cashier', 'Male', '-', '-', '-', '-', '05 01 1996'),
(100003, 'Ryan', 'Balinuyos', 'Aristosa', 'Male', '-', '-', 'ryanaristosa@gmail.com', '-', '27/7/1999'),
(100004, 'Julie Ann', 'Lopez', 'Reodique', 'Female', '-', '-', 'juliereodique@gmail.com', '-', '29/7/2000');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_account_credentials`
--
ALTER TABLE `tbl_account_credentials`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `tbl_activity_log`
--
ALTER TABLE `tbl_activity_log`
  ADD PRIMARY KEY (`activity_id`);

--
-- Indexes for table `tbl_coupon`
--
ALTER TABLE `tbl_coupon`
  ADD PRIMARY KEY (`coupon_ID`);

--
-- Indexes for table `tbl_products`
--
ALTER TABLE `tbl_products`
  ADD PRIMARY KEY (`product_id`);

--
-- Indexes for table `tbl_sales_report`
--
ALTER TABLE `tbl_sales_report`
  ADD PRIMARY KEY (`sales_id`);

--
-- Indexes for table `tbl_tax_discount`
--
ALTER TABLE `tbl_tax_discount`
  ADD PRIMARY KEY (`percent_id`);

--
-- Indexes for table `tbl_user_information`
--
ALTER TABLE `tbl_user_information`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_account_credentials`
--
ALTER TABLE `tbl_account_credentials`
  MODIFY `user_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=100005;
--
-- AUTO_INCREMENT for table `tbl_activity_log`
--
ALTER TABLE `tbl_activity_log`
  MODIFY `activity_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1911;
--
-- AUTO_INCREMENT for table `tbl_sales_report`
--
ALTER TABLE `tbl_sales_report`
  MODIFY `sales_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=112;
--
-- AUTO_INCREMENT for table `tbl_user_information`
--
ALTER TABLE `tbl_user_information`
  MODIFY `user_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=100005;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
