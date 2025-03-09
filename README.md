
# FilmSitesi

FilmSitesi, ASP.NET Core MVC kullanılarak geliştirilmiş bir film yönetim sistemidir. Kullanıcıların film ve oyuncularla ilgili CRUD (Create, Read, Update, Delete) işlemleri yapabilmesini sağlayan bir web uygulamasıdır. Bu proje, Entity Framework Core ile veritabanı yönetimi sağlarken, kullanıcı dostu bir arayüz ile etkileşim imkanı sunar.

## Özellikler

- **Film Yönetimi:** Yeni filmler ekleyebilir, güncelleyebilir, silebilir ve listeleyebilirsiniz.
- **Oyuncu Yönetimi:** Oyuncuların bilgilerini ekleyebilir, güncelleyebilir ve silebilirsiniz.
- **Film-Oyuncu Eşleştirmesi:** Filmlere oyuncu ekleyerek ilişkili bilgileri yönetebilirsiniz.
- **Veritabanı Entegrasyonu:** Entity Framework Core ile SQL Server kullanılarak veri saklama işlemleri gerçekleştirilmiştir.

## Kullanılan Teknolojiler

- **ASP.NET Core MVC** - Web uygulaması geliştirme
- **Entity Framework Core** - ORM (Object-Relational Mapping) kullanımı
- **SQL Server** - Veritabanı yönetimi
- **Bootstrap** - Kullanıcı arayüzü geliştirme

## Kullanım

### 1. Film Ekleme
- **Ana sayfada** bulunan "Film Ekle" butonu ile yeni bir film ekleyebilirsiniz.
- Film adı, açıklaması ve resim URL'si gibi bilgileri girerek kaydedebilirsiniz.

### 2. Oyuncu Yönetimi
- "Oyuncular" sekmesi altında yeni oyuncular ekleyebilir ve mevcut oyuncuları güncelleyebilirsiniz.

### 3. Filmlere Oyuncu Ekleme
- Filmlerin detay sayfasına giderek "Oyuncu Ekle" formunu kullanabilirsiniz.
- Oyuncu listesi içerisinden seçim yaparak ekleme işlemini gerçekleştirebilirsiniz.

## Proje Yapısı

```
FilmSitesi/
│── Controllers/       # MVC Controller dosyaları
│── Models/            # Veritabanı modelleri
│── Views/             # Razor View dosyaları (HTML, CSS, C# kodları)
│── Migrations/        # Veritabanı migrasyon dosyaları
│── wwwroot/           # Statik dosyalar (CSS, JS, resimler)
│── appsettings.json   # Konfigürasyon dosyası
│── Program.cs         # Uygulama giriş noktası
```


## Kullanım (Code Kısmı)

### Film Listesi Görüntüleme
```csharp
public IActionResult Index()
{
    var movies = _context.Movies.Include(m => m.MovieActors).ThenInclude(ma => ma.Actor).ToList();
    return View(movies);
}
```

### Filme Oyuncu Ekleme
```csharp
[HttpPost]
public IActionResult AddMovieActor(int id, int ActorId)
{
    var movieActor = new MovieActor
    {
        MovieId = id,
        ActorId = ActorId
    };
    _context.MovieActor.Add(movieActor);
    _context.SaveChanges();
    return RedirectToAction("Index");
}
```

### Filme Oyuncu Ekleme Görünümü
```html
@model Movie
@{
    List<Actor> actors = ViewBag.Actors;
}
<form action="/Home/AddMovieActor" method="post">
    <input type="hidden" name="MovieId" value="@Model.Id" />
    <select class="form-select" name="ActorId">
        @foreach (var actor in actors)
        {
            <option value="@actor.Id">@actor.FullName</option>
        }
    </select>
    <button type="submit" class="btn btn-primary">Oyuncu Ekle</button>
</form>
```

Bu proje hakkında daha fazla bilgi için [proje deposuna](https://github.com/mertagralii/FilmSitesi) göz atabilirsiniz.



