# Instrukcja do odpalania bazy danych
# Add-Migration InitialMigration -context DatabaseContext
# Update-Database -context DatabaseContext
# Directory C:\Users\user\Downloads\WpfApp1\WpfApp1\WpfApp1
 insert into [MoviesRental].[dbo].[Users] ([Login],[Password],[Name],[Surname],[Email])
 values ('admin','admin','Kamil','Rzezniczek','kamil.rzeniczek@gmail.com')
 
   insert into [MoviesRental].[dbo].[Movies] (Title,[Description],Director,TimeLapse,Category,IsRented) values ('W pustyni i puszczy',
  'Fajny ciekawy film','Aleksander Fredro',90,'Przygodowe',0)
