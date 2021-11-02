// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.PlacesCollection
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;
using System.Collections.Generic;

namespace SpeakIfaceTest1
{
  public class PlacesCollection
  {
    private Dictionary<string, Place> m_places;

    public Dictionary<string, Place> Places
    {
      get
      {
        return this.m_places;
      }
      set
      {
        this.m_places = value;
      }
    }

    public PlacesCollection()
    {
      this.m_places = new Dictionary<string, Place>();
    }

    public void Add(Place p)
    {
      foreach (string key in p.GetSynonims())
      {
        if (this.m_places.ContainsKey(key))
        {
          this.Remove(p);
          throw new Exception(string.Format("Ошибка: Синоним {0} места {1} уже существует в словаре мест.", (object) key, (object) p.Title));
        }
        this.m_places.Add(key, p);
      }
    }

    public void Remove(Place p)
    {
      List<string> list = new List<string>();
      foreach (KeyValuePair<string, Place> keyValuePair in this.m_places)
      {
        if (keyValuePair.Value == p)
          list.Add(keyValuePair.Key);
      }
      foreach (string key in list)
        this.m_places.Remove(key);
      list.Clear();
    }

    internal bool ContainsPlace(string name)
    {
      return this.m_places.ContainsKey(name);
    }

    public Place GetPlace(string text)
    {
      string key = text.Trim();
      if (this.m_places.ContainsKey(key))
        return this.m_places[key];
      return (Place) null;
    }

    internal void FillHardcodedPlaces()
    {
      Place p1 = new Place();
      p1.Title = "Браузер";
      p1.Synonim = "браузер, браузера, браузеру, браузером, браузере";
      p1.Description = "Программа веб-браузера как место";
      p1.Path = "C:\\Program Files\\Internet Explorer\\iexplore.exe";
      p1.PlaceTypeExpression = "Приложение::ВебБраузер<Файл::ФайлHtml, ВебАдрес>";
      p1.ParseEntityTypeString();
      this.Add(p1);
      Place p2 = new Place();
      p2.Title = "Мой сайт";
      p2.Synonim = "мой сайт, моего сайта, моему сайту, моим сайтом, моем сайте";
      p2.Description = "Мой сайт в интернете как место";
      p2.Path = "http://www.meraman.com";
      p2.PlaceTypeExpression = "ВебАдрес";
      p2.ParseEntityTypeString();
      this.Add(p2);
      Place p3 = new Place();
      p3.Title = "Мои проекты";
      p3.Synonim = "мои проекты, моих проектов, моим проектам, моими проектами, моих проектах";
      p3.Description = "Мои проекты";
      p3.Path = "V:\\Projects";
      p3.PlaceTypeExpression = "Каталог::МоиПроекты<Проект, Файл>";
      p3.ParseEntityTypeString();
      this.Add(p3);
      Place p4 = new Place();
      p4.Title = "Студия";
      p4.Synonim = "студия, студии, студию, студией";
      p4.Description = "Моя студия приложение как место";
      p4.Path = "C:\\Program Files\\Microsoft Visual Studio 9.0\\Common7\\IDE\\devenv.exe";
      p4.PlaceTypeExpression = "Приложение::IDE<Солюшен, Файл>";
      p4.ParseEntityTypeString();
      this.Add(p4);
      Place p5 = new Place();
      p5.Title = "MSDN help";
      p5.Synonim = "msdn, мсдн, мсдна, мсдну, мсдном, мсдне";
      p5.Description = "Приложение MSDN";
      p5.Path = "C:\\Program Files\\Common Files\\Microsoft Shared\\Help 9\\dexplore.exe /helpcol ms-help://MS.MSDNQTR.v90.en /LaunchNamedUrlTopic DefaultPage";
      p5.PlaceTypeExpression = "Приложение::MSDN";
      p5.ParseEntityTypeString();
      this.Add(p5);
      Place p6 = new Place();
      p6.Title = "Инвентарь";
      p6.Synonim = "инвентарь, инвентаря, инвентарю, инвентарем, инвентаре";
      p6.Description = "Инвентарь приложение как место";
      p6.Path = "C:\\Program Files\\Inventory\\Inventory.exe";
      p6.PlaceTypeExpression = "Приложение::Инвентарь<Категория, Контейнер, Предмет>";
      p6.ParseEntityTypeString();
      this.Add(p6);
      Place p7 = new Place();
      p7.Title = "Блокнот";
      p7.Synonim = "блокнот, блокнота, блокноту,  блокнотом, блокноте";
      p7.Description = "Блокнот приожение как место";
      p7.Path = "notepad.exe";
      p7.PlaceTypeExpression = "Приложение::ТекстовыйРедактор<Файл>";
      p7.ParseEntityTypeString();
      this.Add(p7);
      Place p8 = new Place();
      p8.Title = "Дневник";
      p8.Synonim = "дневник, дневника, дневнику, дневником, дневнике";
      p8.Description = "Дневник приложение как место";
      p8.Path = "wiki:///V:/Projects/myWiki/MyWiki/MyWiki.wiki?page=Дневник2016";
      p8.PlaceTypeExpression = "ВикиСтраница<Текст>";
      p8.ParseEntityTypeString();
      this.Add(p8);
      Place p9 = new Place();
      p9.Title = "Калькулятор";
      p9.Synonim = "калькулятор, калькулятора, калькулятору, калькулятором, калькуляторе";
      p9.Description = "Калькулятор приложение как место";
      p9.Path = "calc.exe";
      p9.PlaceTypeExpression = "Приложение::Калькулятор";
      p9.ParseEntityTypeString();
      this.Add(p9);
      Place p10 = new Place();
      p10.Title = "Word";
      p10.Synonim = "word, ворд, ворда, ворду, вордом, ворде";
      p10.Description = "Word Приложение как место";
      p10.Path = "C:\\Program Files\\Microsoft Office\\OFFICE11\\WINWORD.EXE";
      p10.PlaceTypeExpression = "Приложение::ТекстовыйРедактор<Файл::ДокументWord>";
      p10.ParseEntityTypeString();
      this.Add(p10);
      Place p11 = new Place();
      p11.Title = "Мои Документы";
      p11.Synonim = "мои документы, моих документов, моим документам, моими документами, моих документах";
      p11.Description = "Папка Мои документы";
      p11.Path = "C:\\Documents and Settings\\Smith John\\Мои документы";
      p11.PlaceTypeExpression = "Каталог::МоиДокументы<Каталог, Файл>";
      p11.ParseEntityTypeString();
      this.Add(p11);
      Place p12 = new Place();
      p12.Title = "Моя музыка";
      p12.Synonim = "моя музыка, моей музыки, моей музыке, мою музыку, моей музыкой";
      p12.Description = "Папка Коллекция Моя музыка";
      p12.Path = "C:\\Work\\Музыка";
      p12.PlaceTypeExpression = "Каталог::МояМузыка<Каталог, Файл, Файл::ФайлМузыки>";
      p12.ParseEntityTypeString();
      this.Add(p12);
      Place p13 = new Place();
      p13.Title = "Плеер";
      p13.Synonim = "плеер, плеера, плееру, плеером, плеере";
      p13.Description = "Приложение плеер";
      p13.Path = "C:\\Program Files\\Windows Media Player\\wmplayer.exe";
      p13.PlaceTypeExpression = "Приложение::АудиоПлеер<Файл::ФайлМузыки, Файл::Плейлист>";
      p13.ParseEntityTypeString();
      this.Add(p13);
      Place p14 = new Place();
      p14.Title = "Хиты";
      p14.Synonim = "хиты, хитов, хитам, хитами, хитах";
      p14.Description = "Плейлист отобранных мною хитов";
      p14.Path = "C:\\Documents and Settings\\Smith John\\Мои документы\\Моя музыка\\My Playlists\\хиты.wpl";
      p14.PlaceTypeExpression = "Файл::Плейлист<Файл::ФайлМузыки>";
      p14.ParseEntityTypeString();
      this.Add(p14);
      Place p15 = new Place();
      p15.Title = "ВикиРИ";
      p15.Synonim = "викири";
      p15.Description = "Вики проекта Речевой интерфейс";
      p15.Path = "wiki:///V:/Projects/РечевойИнтерфейс/SpeakWiki/SpeakWiki.wiki?page=SpeakWiki";
      p15.PlaceTypeExpression = "ВикиСтраница<Текст>";
      p15.ParseEntityTypeString();
      this.Add(p15);
    }

    internal void FillFromDb(List<Place> list)
    {
      foreach (Place p in list)
        this.Add(p);
    }

    internal void Clear()
    {
      this.m_places.Clear();
    }

    internal List<Place> getByTitle(string placeTitle)
    {
      List<Place> list = new List<Place>();
      Dictionary<int, Place> dictionary = new Dictionary<int, Place>();
      foreach (Place place in this.m_places.Values)
      {
        if (string.Equals(place.Title, placeTitle, StringComparison.OrdinalIgnoreCase) && !dictionary.ContainsKey(place.TableId))
          dictionary.Add(place.TableId, place);
      }
      list.AddRange((IEnumerable<Place>) dictionary.Values);
      dictionary.Clear();
      return list;
    }
  }
}
