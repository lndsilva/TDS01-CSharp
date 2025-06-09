-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 09/06/2025 às 15:50
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dbfrancisco`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbatribuicoes`
--

CREATE TABLE `tbatribuicoes` (
  `codAtr` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tbatribuicoes`
--

INSERT INTO `tbatribuicoes` (`codAtr`, `nome`) VALUES
(2, 'Acompanhamento do palestrante'),
(1, 'Distribuição dos trabalhadores'),
(5, 'Encerramento de final de mês'),
(3, 'Realizar passe'),
(4, 'Recados para diretoria'),
(6, 'Recepção dos alimentos');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbusuarios`
--

CREATE TABLE `tbusuarios` (
  `codUsu` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `senha` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tbusuarios`
--

INSERT INTO `tbusuarios` (`codUsu`, `nome`, `senha`) VALUES
(1, 'sfrancisco', '123456'),
(2, 'admin', 'admin'),
(5, 'isa.belli', '789456123789'),
(6, 'admin', '123456789123');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbvoluntarios`
--

CREATE TABLE `tbvoluntarios` (
  `codVol` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telCel` char(15) DEFAULT NULL,
  `endereco` varchar(100) DEFAULT NULL,
  `numero` char(5) DEFAULT NULL,
  `cep` char(9) DEFAULT NULL,
  `bairro` varchar(100) DEFAULT NULL,
  `cidade` varchar(100) DEFAULT NULL,
  `estado` char(2) DEFAULT NULL,
  `codAtr` int(11) NOT NULL,
  `data` datetime DEFAULT NULL,
  `hora` datetime DEFAULT NULL,
  `status` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tbvoluntarios`
--

INSERT INTO `tbvoluntarios` (`codVol`, `nome`, `email`, `telCel`, `endereco`, `numero`, `cep`, `bairro`, `cidade`, `estado`, `codAtr`, `data`, `hora`, `status`) VALUES
(1, 'Amarildo Fernadez', 'amarildo.fernadez@gmail.com', '(11)97852-8577', 'Rua Maria Fernadez', '574', '04750-000', 'Santo Amaro', 'Sao Paulo', 'SP', 4, '2025-06-06 00:00:00', '2025-06-09 09:24:00', 1),
(2, 'Fernada Tornado', 'fernanda.tornado@gmail.com', '(11) 9857-4526', 'Rua Doutor Antônio Bento', '255', '04750-000', 'Santo Amaro', 'São Paulo', 'SP', 1, '2025-06-09 10:41:14', '2025-06-09 10:41:14', 1);

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `tbatribuicoes`
--
ALTER TABLE `tbatribuicoes`
  ADD PRIMARY KEY (`codAtr`),
  ADD UNIQUE KEY `nome` (`nome`),
  ADD UNIQUE KEY `codAtr` (`codAtr`);

--
-- Índices de tabela `tbusuarios`
--
ALTER TABLE `tbusuarios`
  ADD PRIMARY KEY (`codUsu`);

--
-- Índices de tabela `tbvoluntarios`
--
ALTER TABLE `tbvoluntarios`
  ADD PRIMARY KEY (`codVol`),
  ADD KEY `codAtr` (`codAtr`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tbatribuicoes`
--
ALTER TABLE `tbatribuicoes`
  MODIFY `codAtr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `tbusuarios`
--
ALTER TABLE `tbusuarios`
  MODIFY `codUsu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `tbvoluntarios`
--
ALTER TABLE `tbvoluntarios`
  MODIFY `codVol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `tbvoluntarios`
--
ALTER TABLE `tbvoluntarios`
  ADD CONSTRAINT `tbvoluntarios_ibfk_1` FOREIGN KEY (`codAtr`) REFERENCES `tbatribuicoes` (`codAtr`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
