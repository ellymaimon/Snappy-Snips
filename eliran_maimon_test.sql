-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 20, 2018 at 11:57 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eliran_maimon_test`
--
CREATE DATABASE IF NOT EXISTS `eliran_maimon_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `eliran_maimon_test`;

-- --------------------------------------------------------

--
-- Table structure for table `Clients`
--

CREATE TABLE `Clients` (
  `ClientId` int(11) NOT NULL,
  `ClientFirstName` longtext,
  `ClientLastName` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Specialties`
--

CREATE TABLE `Specialties` (
  `SpecialtyId` int(11) NOT NULL,
  `Description` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `StylistClients`
--

CREATE TABLE `StylistClients` (
  `StylistClientId` int(11) NOT NULL,
  `ClientId` int(11) NOT NULL,
  `StylistId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Stylists`
--

CREATE TABLE `Stylists` (
  `StylistId` int(11) NOT NULL,
  `StylistFirstName` longtext,
  `StylistLastName` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `StylistSpecialties`
--

CREATE TABLE `StylistSpecialties` (
  `StylistSpecialtyId` int(11) NOT NULL,
  `SpecialtyId` int(11) NOT NULL,
  `StylistId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Clients`
--
ALTER TABLE `Clients`
  ADD PRIMARY KEY (`ClientId`);

--
-- Indexes for table `Specialties`
--
ALTER TABLE `Specialties`
  ADD PRIMARY KEY (`SpecialtyId`);

--
-- Indexes for table `StylistClients`
--
ALTER TABLE `StylistClients`
  ADD PRIMARY KEY (`StylistClientId`),
  ADD KEY `IX_StylistClients_ClientId` (`ClientId`),
  ADD KEY `IX_StylistClients_StylistId` (`StylistId`);

--
-- Indexes for table `Stylists`
--
ALTER TABLE `Stylists`
  ADD PRIMARY KEY (`StylistId`);

--
-- Indexes for table `StylistSpecialties`
--
ALTER TABLE `StylistSpecialties`
  ADD PRIMARY KEY (`StylistSpecialtyId`),
  ADD KEY `IX_StylistSpecialties_SpecialtyId` (`SpecialtyId`),
  ADD KEY `IX_StylistSpecialties_StylistId` (`StylistId`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Clients`
--
ALTER TABLE `Clients`
  MODIFY `ClientId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Specialties`
--
ALTER TABLE `Specialties`
  MODIFY `SpecialtyId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `StylistClients`
--
ALTER TABLE `StylistClients`
  MODIFY `StylistClientId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Stylists`
--
ALTER TABLE `Stylists`
  MODIFY `StylistId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `StylistSpecialties`
--
ALTER TABLE `StylistSpecialties`
  MODIFY `StylistSpecialtyId` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `StylistClients`
--
ALTER TABLE `StylistClients`
  ADD CONSTRAINT `FK_StylistClients_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`ClientId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_StylistClients_Stylists_StylistId` FOREIGN KEY (`StylistId`) REFERENCES `Stylists` (`StylistId`) ON DELETE CASCADE;

--
-- Constraints for table `StylistSpecialties`
--
ALTER TABLE `StylistSpecialties`
  ADD CONSTRAINT `FK_StylistSpecialties_Specialties_SpecialtyId` FOREIGN KEY (`SpecialtyId`) REFERENCES `Specialties` (`SpecialtyId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_StylistSpecialties_Stylists_StylistId` FOREIGN KEY (`StylistId`) REFERENCES `Stylists` (`StylistId`) ON DELETE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
