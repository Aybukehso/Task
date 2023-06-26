![Ekran Alıntısı2](https://github.com/Aybukehso/ErpaTask/assets/115698658/9b1cd4e4-e362-41b7-850e-69c5515ed89e)



Başlık: .NET Core Web API ve Flutter ile Banka Uygulaması

Açıklama:

.NET Core Web API ve Flutter kullanılarak bir banka uygulaması geliştirilmiştir. Projeye başlarken, öncelikle .NET Core Web API projesini oluşturdum , Data ve Model(User,Bank,Account)  katmanlarını Code First yaklaşımıyla tanımladım ve gerekli program.cs, startup.cs klasörlerinin içerisinde gerekli tanımlamalar yapılarak migration işlemlerini gerçekleştirdim. DataBase bağlantısını sağladım.


Oluşturulan User ve Bank tabloları, Account tablosı ile bireçok ilişki olacak şekilde oluşturulmuştur.

Daha sonra, controller(User,Bank,Account) işlemlerini gerçekleştirdim. UserController dosyası içerisinde LINQ sorgularını ekleyerek user login işlemi gerçekleştirildi. BankController'ın içinde Banka oluşturma,banka silme ve banka listeleme işlemlerini gerçekleştirebilecek kodları yazdım. AccountController içerisinde Para Yükleme,Para Çekme ve Para isteme metodlarını ekledim. Banka ekle metodu çalıştırıldığında Account tablosunda, o bankaya ait hesap oluşturulmaktadır. 

Kodlarımı Postman programı aracılığıyla  get,post,delete gibi istekleri göndermek için test ettim ve başarılı sonuçlar elde ettim. Ardından, Flutter kullanarak bir giriş sayfası ve ana ekran tasarladım. Giriş sayfasında email ve Password kontrolü için Api isteği oluşturdum. Başarılı giriş sonucu ikinci bir sayfaya yönlendirme işlemi gerçekleştirdim. Bu ekran üzerinde para yükleme, para çekme ve para talebi butonlarından oluşmaktadır . Bu butonlara tıklanıldığında ilgili API istekleri gerçekleşmektedir.

Kullanılan programlama dilleri:
Asp.NET Core 7, Flutter ,MsSQL

Yararlanılan program:
Postman 
