# Operator
Command-line shell for semantic experiments. 

System requirements:
- 32-bit Windows XP Service Pack 2, Windows Vista, Windows 7.
- .NET Framework 2.0.
- Russificated user.

1 Дата начала: 27 октября 2021 г.

2 Название: РечевойИнтерфейс

3 Краткое описание: Разработка теории и прототипа Оператор

4 Описание: 

4.1 Обстановка и причины создания проекта: 
Для упрощения и ускорения работы решено создать  текстовое приложение - консоль для автоматизации работ на компьютере.

4.2 Конечный результат проекта:  
- Прототип приложения консоли.
- Теория работы консоли Речевого интерфейса.
- документация на прототип консоли.

4.3 Предполагаемая ситуация для использования проекта: 
- повседневная работа на компьютере.
- выполнение проектов на компьютере.

4.4 Предполагаемая трудоемкость проекта: 
- более 1 года.

4.5 Текущее состояние проекта: Инициализация 

4.6 План работы: 

4.7 Замечания: 



# Как пользоваться Оператор (на примере компьютера с ОС Виндовс 7 32-bit)

1. распаковываем архив в каталог на диске С.
2. запускаем Operator.exe
3. Видим:
Консоль речевого интерфейса. Версия 1.0.7.12
Для завершения работы приложения введите слово выход или quit
Сегодня вторник, 9 ноября 2021г. 20:21:47

Введите ваш запрос:

4. Нужно ввести команду на обычном русском языке.
Команда должна начинаться с глагола в первичной форме (безличном повелительном наклонении).
Может обнаружиться путаница между Командами и Процедурами. 
Команда - это Запрос, который пользователь вводит с клавиатуры.
Процедура - это алгоритм, который был выбран для введенного Запроса и выполняется, исполняя Команду.
 Алгоритм выбора Процедуры для Запроса потребовал некоторой гениальности, но пока все идет хорошо.
Сейчас из Оператор можно создавать новые Команды (Команда Создать команду Текст Команды), но нельзя редактировать и удалять. 
 Для редактирования и удаления Команд редактируйте БД Оператора вручную.

 Вводим:
показать команды

5. Видим:
Начата процедура CommandListProcedures()

Список всех Команд Оператора:

Добавить принтер [Показать диалог Добавить принтер]
Играть файл Х [Играть файл в плеере]
Играть Х [Играть файл в плеере]
Извлечь диск [Показать диалог Извлечение устройства]
Извлечь устройство [Показать диалог Извлечение устройства]
Извлечь флешку [Показать диалог Извлечение устройства]
Напечатать тестовую страницу [Напечатать тестовую страницу]
Отключить сетевой диск [Отключить сетевой диск, если они есть]
Открыть заметку Х [Открыть заметку НазваниеЗаметки на рабочем столе]
Открыть панель управления [Открыть панель управления]
Открыть Х [Использование Мест]
Подключить сетевой диск [Показать диалог Подключить сетевой диск]
Показать команды [Вывести список существующих Команд]
Показать места [Вывести список существующих Мест]
Показать принтеры [Показать диалог Принтеры]
...

6. Сущности, такие как программы, папки или файлы, сайты, итп - можно назвать более удобными именами. 
Это подобно ярлыкам, но имеет 6 падежных форм склонений для каждого такого названия Сущности.
В документации проекта пока что Сущность называется Местом. 
Сейчас из Оператор можно создавать новые Места (Команда Создать место Название места), но нельзя редактировать и удалять. 
 Для редактирования и удаления Мест редактируйте БД Оператора вручную.
 
Вводим:
показать места

7. Видим:
Начата процедура CommandListPlaces()

Список всех Мест Оператора

Word [C:\Program Files\Microsoft Office\OFFICE11\WINWORD.EXE]
Блокнот [notepad.exe]
Браузер [C:\Program Files\Internet Explorer\iexplore.exe]
Калькулятор [calc.exe]
Консоль [C:\windows\system32\cmd.exe]
Мои Документы [C:\Documents and Settings\Администратор\Мои документы]
Паук [C:\windows\system32\spider.exe]
Проводник [C:\Windows\explorer.exe]
Скандиск [C:\WINDOWS\system32\chkdsk]
Слон [https://www.slon.ru]
темп [C:\Temp]
Терминал [C:\windows\system32\cmd.exe]
Топвар [https://www.topwar.ru]
Тотал [C:\Program Files\TC\TOTALCMD.EXE]

Выведен список Мест


Введите ваш запрос:

8. Создание заметок на рабочем столе
Это пример полезной функциональности Оператор. 
Можно приступить к записи заметки сразу же, немедленно после озарения, не теряя времени.
Две команды: "Создать заметку Название заметки"  и "Открыть заметку Название заметки". 
Удалить заметку из Оператор нельзя - заметки же не для того пишут, чтобы их удалять.

9. Англоязычные запросы Оператор сам не исполняет, а перекидывает их в терминал ОС.
Текущим каталогом терминала назначается папка Мои документы.
Вводим:
format c: 

10. Видим:
Тип файловой системы: NTFS.

ВНИМАНИЕ, ВСЕ ДАННЫЕ НА НЕСЪЕМНОМ
ДИСКЕ C: БУДУТ УНИЧТОЖЕНЫ!
Приступить к форматированию [Y(да)/N(нет)]?

11. Последовательно нажимаем клавиши Y и Enter, чтобы завершить эту операцию и закрыть окно консоли cmd.exe.

12. Завершение Оператор
Закрыть окно Оператор нажатием на стандартный крестик в заголовке окна - нельзя. 
Также не сработают комбинации клавиш Alt+F4, Ctrl+C, Break.
Окно Оператор можно закрыть нажатием комбинации клавиш Ctrl+Break.  Или введя команду выход.
Также, можно выключить, усыпить или перезагрузить компьютер, введя команды:
спать
перезагрузка
выключить компьютер

13. Чтобы Оператор всегда оказывался под рукой, добавьте его ярлык в меню Пуск - Автозагрузка. Он будет загружаться каждый раз при запуске сеанса пользователя.
Добавив в Оператор нужные вам Команды и Места, вы сможете забыть об этом сложном и жутком графическом интерфейсе Виндовс и восславить великий русский язык.
На этом пока все. Приятного вам дня!


 








