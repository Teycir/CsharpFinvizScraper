CREATE TABLE `wsjdata` (
  `ticker` varchar(10) NOT NULL,
  `date` datetime NOT NULL,
  `pricechange` float DEFAULT NULL,
  `uptickdowntick` float DEFAULT NULL,
  `sector` varchar(100) DEFAULT NULL,
  `industry` varchar(100) DEFAULT NULL,
  `country` varchar(100) DEFAULT NULL,
  `isdivergent` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$

;