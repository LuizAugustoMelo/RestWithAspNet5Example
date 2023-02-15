CREATE TABLE IF NOT EXISTS `users` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) NOT NULL DEFAULT '0',
  `full_name` varchar(120) NOT NULL,
  `password` varchar(130) NOT NULL DEFAULT '0',
  `refresh_token` varchar(500) NOT NULL DEFAULT '0',
  `refresh_token_expiry_time` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE `user_name` (`user_name`)
)
