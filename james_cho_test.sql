-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Dec 08, 2018 at 12:52 AM
-- Server version: 5.7.23
-- PHP Version: 7.2.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `james_cho_test`
--
CREATE DATABASE IF NOT EXISTS `james_cho_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `james_cho_test`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `name` varchar(255) NOT NULL,
  `phone` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`name`, `phone`, `stylist_id`, `id`) VALUES
('melissa', 15487589, 22, 2),
('michael b jordan', 88888, 22, 5),
('michael', 3, 22, 6),
('adam', 71542, 23, 7),
('david', 232323, 23, 8),
('batman', 777, 24, 9),
('superman', 888, 24, 11),
('Bob', 7777777, 0, 12),
('Jim', 8888888, 0, 13),
('Bob', 7777777, 30, 14),
('Jim', 8888888, 30, 15),
('Bob', 7777777, 36, 16),
('Bob', 7777777, 39, 17),
('Bob', 7777777, 42, 18),
('Bob', 7777777, 45, 19),
('Bob', 7777777, 48, 20),
('Bob', 7777777, 51, 21),
('Bob', 7777777, 54, 22),
('Bob', 7777777, 57, 23),
('Bob', 7777777, 60, 24);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `name` varchar(255) NOT NULL,
  `specialty` varchar(255) NOT NULL,
  `schedule` varchar(255) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
