-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: dagal
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `agenda`
--

DROP TABLE IF EXISTS `agenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agenda` (
  `idAgenda` int NOT NULL AUTO_INCREMENT,
  `nActividad` int NOT NULL,
  `actividad` varchar(200) NOT NULL,
  `idEvento` int NOT NULL,
  PRIMARY KEY (`idAgenda`),
  KEY `idEvento` (`idEvento`),
  CONSTRAINT `agenda_ibfk_1` FOREIGN KEY (`idEvento`) REFERENCES `evento` (`idEvento`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agenda`
--

LOCK TABLES `agenda` WRITE;
/*!40000 ALTER TABLE `agenda` DISABLE KEYS */;
INSERT INTO `agenda` VALUES (7,1,'entrada',11),(8,2,'pastel',11),(12,1,'Entrada',16),(13,2,'Show de standup',16),(14,3,'Anecdotario',16),(15,4,'Quioña datos',16),(16,5,'Cierre',16);
/*!40000 ALTER TABLE `agenda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `idCliente` int NOT NULL AUTO_INCREMENT,
  `idPersona` int NOT NULL,
  PRIMARY KEY (`idCliente`),
  KEY `idPersona` (`idPersona`),
  CONSTRAINT `cliente_ibfk_1` FOREIGN KEY (`idPersona`) REFERENCES `persona` (`idPersona`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,2),(2,4),(8,15);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `duracion`
--

DROP TABLE IF EXISTS `duracion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `duracion` (
  `idDuracion` int NOT NULL AUTO_INCREMENT,
  `duracion` varchar(10) NOT NULL,
  PRIMARY KEY (`idDuracion`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `duracion`
--

LOCK TABLES `duracion` WRITE;
/*!40000 ALTER TABLE `duracion` DISABLE KEYS */;
INSERT INTO `duracion` VALUES (1,'1.0'),(2,'2.0'),(3,'3.0'),(4,'4.0'),(5,'5.0'),(6,'8.0');
/*!40000 ALTER TABLE `duracion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evento`
--

DROP TABLE IF EXISTS `evento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evento` (
  `idEvento` int NOT NULL AUTO_INCREMENT,
  `evento` varchar(200) NOT NULL,
  `fecha` datetime NOT NULL,
  `duracion` decimal(3,1) NOT NULL,
  `lugar` varchar(50) NOT NULL,
  `idTipoEvento` int NOT NULL,
  `idCliente` int NOT NULL,
  `costo` decimal(6,2) NOT NULL,
  `idUsuario` int NOT NULL,
  PRIMARY KEY (`idEvento`),
  KEY `idTipoEvento` (`idTipoEvento`),
  KEY `idCliente` (`idCliente`),
  KEY `idUsuario` (`idUsuario`),
  CONSTRAINT `evento_ibfk_1` FOREIGN KEY (`idTipoEvento`) REFERENCES `tipoevento` (`idTipoEvento`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `evento_ibfk_2` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`idCliente`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `evento_ibfk_3` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evento`
--

LOCK TABLES `evento` WRITE;
/*!40000 ALTER TABLE `evento` DISABLE KEYS */;
INSERT INTO `evento` VALUES (11,'cumple LH','2023-06-10 19:00:00',5.0,'salon 1',1,1,100.00,16),(14,'cumple nano','2023-06-29 20:00:00',4.0,'asd',1,2,400.00,23),(16,'Cotorrisa','2023-06-16 20:00:00',5.0,'Teatro Nacional',8,8,700.00,23);
/*!40000 ALTER TABLE `evento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hora`
--

DROP TABLE IF EXISTS `hora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hora` (
  `idHora` int NOT NULL AUTO_INCREMENT,
  `hora` varchar(10) NOT NULL,
  PRIMARY KEY (`idHora`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hora`
--

LOCK TABLES `hora` WRITE;
/*!40000 ALTER TABLE `hora` DISABLE KEYS */;
INSERT INTO `hora` VALUES (1,'07:00:00'),(2,'08:00:00'),(3,'09:00:00'),(4,'10:00:00'),(5,'11:00:00'),(6,'12:00:00'),(7,'13:00:00'),(8,'14:00:00'),(9,'15:00:00'),(10,'16:00:00'),(11,'17:00:00'),(12,'18:00:00'),(13,'19:00:00'),(14,'20:00:00');
/*!40000 ALTER TABLE `hora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `nombrecomplet`
--

DROP TABLE IF EXISTS `nombrecomplet`;
/*!50001 DROP VIEW IF EXISTS `nombrecomplet`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `nombrecomplet` AS SELECT 
 1 AS `idPersona`,
 1 AS `nombreCompleto`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `persona` (
  `idPersona` int NOT NULL AUTO_INCREMENT,
  `dui` varchar(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `correo` varchar(80) NOT NULL,
  `telefono` varchar(9) NOT NULL,
  PRIMARY KEY (`idPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` VALUES (2,'07811063-0','Lewis','Hamilton','lewishamilton@correo.com','7136-7544'),(3,'01364542-3','Sergio','Perez','sergioperez@correo.com','7641-6411'),(4,'03486332-4','Fernando','Alonso','fernandoalonso@correo.com','7733-3514'),(9,'01294790-2','Carlos','Sainz','csainz@correo.com','1234-7821'),(13,'19047302-1','Jose','Slobotzky','slobo@correo.com','1341-2412'),(14,'12345678-9','Salma','Hayek','salma@correo.com','3245-6787'),(15,'79779879-7','Ricardo','Perez','ricardoperez@correo.com','7987-9009'),(16,'98968768-9','Mariana','Chavez','mariana@correo.com','9807-7896'),(19,'90770970-7','Ayrton','Senna','asenna@correo.com','6869-8698'),(21,'87908709-7','Jon','Snow','reyenelnorte@correo.com','9077-0970');
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoevento`
--

DROP TABLE IF EXISTS `tipoevento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipoevento` (
  `idTipoEvento` int NOT NULL AUTO_INCREMENT,
  `tipoEvento` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idTipoEvento`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoevento`
--

LOCK TABLES `tipoevento` WRITE;
/*!40000 ALTER TABLE `tipoevento` DISABLE KEYS */;
INSERT INTO `tipoevento` VALUES (1,'Cumpleaños'),(2,'Graduacion'),(3,'Boda'),(6,'Clase'),(8,'Show de comedia');
/*!40000 ALTER TABLE `tipoevento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipousuario`
--

DROP TABLE IF EXISTS `tipousuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipousuario` (
  `idTipoUsuario` int NOT NULL AUTO_INCREMENT,
  `tipoUsuario` varchar(15) NOT NULL,
  PRIMARY KEY (`idTipoUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipousuario`
--

LOCK TABLES `tipousuario` WRITE;
/*!40000 ALTER TABLE `tipousuario` DISABLE KEYS */;
INSERT INTO `tipousuario` VALUES (1,'Administrador'),(2,'Usuario');
/*!40000 ALTER TABLE `tipousuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `idUsuario` int NOT NULL AUTO_INCREMENT,
  `usuario` varchar(20) NOT NULL,
  `contra` varchar(500) NOT NULL,
  `idTipoUsuario` int NOT NULL,
  `idPersona` int NOT NULL,
  PRIMARY KEY (`idUsuario`),
  KEY `idTipoUsuario` (`idTipoUsuario`),
  KEY `idPersona` (`idPersona`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`idTipoUsuario`) REFERENCES `tipousuario` (`idTipoUsuario`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `usuario_ibfk_2` FOREIGN KEY (`idPersona`) REFERENCES `persona` (`idPersona`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (16,'csainz','f10e2821bbbea527ea02200352313bc059445190',2,9),(20,'sperez','f10e2821bbbea527ea02200352313bc059445190',1,3),(23,'jslobotzky','f10e2821bbbea527ea02200352313bc059445190',2,13),(24,'shayek','096459e93f20a2b39ab6c5ddd493e44f58bc3a91',1,14),(25,'mchavez','f10e2821bbbea527ea02200352313bc059445190',1,16),(27,'asenna','f10e2821bbbea527ea02200352313bc059445190',1,19);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vagenda`
--

DROP TABLE IF EXISTS `vagenda`;
/*!50001 DROP VIEW IF EXISTS `vagenda`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vagenda` AS SELECT 
 1 AS `idAgenda`,
 1 AS `nActividad`,
 1 AS `actividad`,
 1 AS `evento`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vcliente`
--

DROP TABLE IF EXISTS `vcliente`;
/*!50001 DROP VIEW IF EXISTS `vcliente`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vcliente` AS SELECT 
 1 AS `idCliente`,
 1 AS `nombreCompleto`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vclientes`
--

DROP TABLE IF EXISTS `vclientes`;
/*!50001 DROP VIEW IF EXISTS `vclientes`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vclientes` AS SELECT 
 1 AS `idPersona`,
 1 AS `nombreCompleto`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vempleado`
--

DROP TABLE IF EXISTS `vempleado`;
/*!50001 DROP VIEW IF EXISTS `vempleado`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vempleado` AS SELECT 
 1 AS `idPersona`,
 1 AS `nombreCompleto`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vevento`
--

DROP TABLE IF EXISTS `vevento`;
/*!50001 DROP VIEW IF EXISTS `vevento`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vevento` AS SELECT 
 1 AS `idEvento`,
 1 AS `evento`,
 1 AS `fecha`,
 1 AS `duracion`,
 1 AS `lugar`,
 1 AS `tipoEvento`,
 1 AS `nombreCompleto`,
 1 AS `costo`,
 1 AS `usuario`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vusuario`
--

DROP TABLE IF EXISTS `vusuario`;
/*!50001 DROP VIEW IF EXISTS `vusuario`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vusuario` AS SELECT 
 1 AS `idUsuario`,
 1 AS `usuario`,
 1 AS `contra`,
 1 AS `tipoUsuario`,
 1 AS `Empleado`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `nombrecomplet`
--

/*!50001 DROP VIEW IF EXISTS `nombrecomplet`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `nombrecomplet` AS select `persona`.`idPersona` AS `idPersona`,concat(`persona`.`nombre`,' ',`persona`.`apellido`) AS `nombreCompleto` from `persona` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vagenda`
--

/*!50001 DROP VIEW IF EXISTS `vagenda`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vagenda` AS select `a`.`idAgenda` AS `idAgenda`,`a`.`nActividad` AS `nActividad`,`a`.`actividad` AS `actividad`,`e`.`evento` AS `evento` from (`agenda` `a` join `evento` `e`) where (`a`.`idEvento` = `e`.`idEvento`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vcliente`
--

/*!50001 DROP VIEW IF EXISTS `vcliente`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vcliente` AS select `c`.`idCliente` AS `idCliente`,concat(`p`.`nombre`,' ',`p`.`apellido`) AS `nombreCompleto` from (`persona` `p` join `cliente` `c`) where (`p`.`idPersona` = `c`.`idPersona`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vclientes`
--

/*!50001 DROP VIEW IF EXISTS `vclientes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vclientes` AS select `p`.`idPersona` AS `idPersona`,concat(`p`.`nombre`,' ',`p`.`apellido`) AS `nombreCompleto` from (`persona` `p` left join `usuario` `u` on((`p`.`idPersona` = `u`.`idPersona`))) where (`u`.`idPersona` is null) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vempleado`
--

/*!50001 DROP VIEW IF EXISTS `vempleado`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vempleado` AS select `p`.`idPersona` AS `idPersona`,concat(`p`.`nombre`,' ',`p`.`apellido`) AS `nombreCompleto` from (`persona` `p` left join `cliente` `c` on((`p`.`idPersona` = `c`.`idPersona`))) where (`c`.`idCliente` is null) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vevento`
--

/*!50001 DROP VIEW IF EXISTS `vevento`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vevento` AS select `e`.`idEvento` AS `idEvento`,`e`.`evento` AS `evento`,`e`.`fecha` AS `fecha`,`e`.`duracion` AS `duracion`,`e`.`lugar` AS `lugar`,`t`.`tipoEvento` AS `tipoEvento`,`c`.`nombreCompleto` AS `nombreCompleto`,`e`.`costo` AS `costo`,`u`.`usuario` AS `usuario` from (((`evento` `e` join `tipoevento` `t`) join `vcliente` `c`) join `usuario` `u`) where ((`e`.`idTipoEvento` = `t`.`idTipoEvento`) and (`e`.`idCliente` = `c`.`idCliente`) and (`e`.`idUsuario` = `u`.`idUsuario`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vusuario`
--

/*!50001 DROP VIEW IF EXISTS `vusuario`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vusuario` AS select `u`.`idUsuario` AS `idUsuario`,`u`.`usuario` AS `usuario`,`u`.`contra` AS `contra`,`t`.`tipoUsuario` AS `tipoUsuario`,concat(`p`.`nombre`,' ',`p`.`apellido`) AS `Empleado` from ((`usuario` `u` join `tipousuario` `t`) join `persona` `p`) where ((`u`.`idTipoUsuario` = `t`.`idTipoUsuario`) and (`u`.`idPersona` = `p`.`idPersona`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-14 18:43:56
