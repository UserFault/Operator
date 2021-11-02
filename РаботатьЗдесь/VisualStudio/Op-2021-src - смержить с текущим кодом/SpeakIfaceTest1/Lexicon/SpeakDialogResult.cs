// Decompiled with JetBrains decompiler
// Type: SpeakIfaceTest1.Lexicon.SpeakDialogResult
// Assembly: SpeakIfaceTest1, Version=1.0.6.11, Culture=neutral, PublicKeyToken=null
// MVID: 976A6B55-C14F-4871-8987-3516C03DB3B9
// Assembly location: C:\Users\Администратор\Desktop\Щз-1\SpeakIfaceTest1.exe

using System;

namespace SpeakIfaceTest1.Lexicon
{
  [Flags]
  public enum SpeakDialogResult
  {
    Unknown = 0,
    Да = 1,
    Нет = 2,
    Отмена = 4,
    Прервать = 8,
    Повторить = 16,
    Пропустить = 32,
    Отложить = 64,
    ДаНетОтмена = Отмена | Нет | Да,
  }
}
