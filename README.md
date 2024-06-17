Projeto foi desenvolvido utilizando .NET 5 e PostgreSQL10 com EntityFramework. 
Como o banco de dados foi gerado usando code-first, para configurar local será necessário seguir os passos.

1.Ter o postgreSQL 10 instalado na máquina.
2.Setar os dados do seu servidor local na connectionString localizada na  appsetings.json. 
3.Abrir o console do nuget e rodar o comando "update-database". 

O DataBase será gerado automáticamente na conexão estabelecida.
