# ВВЕДЕНИЕ В WPF

Windows Presentation Foundation (WPF) — фреймворк для построения настольных
приложений Windows. WPF поддерживает широкий набор функций разработки
приложений, включая модель приложения (application model), ресурсы (resources),
элементы управления (controls, графику (graphics), компоновка (layout), привязку
данных (data binding) и документы (documents). Он также является наиболее
радикальным изменением в пользовательском интерфейсе Windows со времен Windows
95.

> :grey_exclamation: WPF и Windows Forms были мигрированы на кросс-платформенный
  фреймворк .NET Core 3.0 и, вместе с тем, на модель распространения с открытым
  исходным кодом. Но это не означает, что приложения, построенные на базе этих
  фреймворков, будут кросс-платформенными (запускаться в операционных системах,
  отличных от Windows), так как их внутреннее устройство все еще сильно завязано
  на эту операционную систему. Изменение касается того, что теперь проект
  приложения WPF или Windows Forms может быть собран не только на Windows.

> :grey_exclamation: Для создания современных настольных кросс-платформенных
  приложений стоит обратиться к фреймворкам, основанным на Node.js: Electron (VS
  Code, GitHub Desktop, Slack, Skype), NW.js, App.js, Meteor.

## История

Разработчики Windows-приложений в течение более 15 лет пользовались, по сути,
одной и той же технологией отображения. Стандартное Windows-приложение при
создании пользовательского интерфейса полагается на две основополагающие части
операционной системы Windows, которые появились в Windows 1.0 еще в 1985 году:
интерфейс графического устройства (Graphics Device Interface, GDI) и подсистема
User.

* User обеспечивает знакомый внешний вид и поведение таких элементов, как
  окна, кнопки, текстовые поля и т.п.;

* GDI/GDI+ предоставляет поддержку рисования фигур, текста и изображений.

После появления каркаса .NET и управляемого кода (в 2002 году) разработчики
получили очень продуктивную модель для создания Windows и веб-приложений.
Включенная в нее технология Windows Forms (основанная на GDI+) стала основным
способом создания пользовательских интерфейсов в Windows для разработчиков на
C#, Visual Basic и (в меньшей степени) С++. Она пользовалась успехом и оказалась
весьма продуктивной, но имела фундаментальные ограничения, уходящие корнями в
GDI+ и подсистему User.

Хотя Windows Forms — зрелый и полнофункциональный набор инструментов, он был
тесно привязан к некоторым частям внутреннего устройства Windows, которые не
слишком изменились за последние 10 лет. Что более существенно, при создании
визуального представления стандартных пользовательских интерфейсных элементов,
таких как кнопки, текстовые поля, флажки и т.п., Windows Forms полагается на
Windows API. В результате его ингредиенты мало поддаются настройке и изменениям.

Например, чтобы построить стилизованную блестящую кнопку, придется создать
специальный элемент управления и нарисовать каждый аспект этой новой кнопки (во
всех разных состояниях), используя низкоуровневую модель рисования. И не стоит
даже думать о создании анимационных эффектов вроде вращающегося текста,
мерцающих кнопок, сворачивающихся окон или активных предварительных просмотров,
потому что каждая деталь должна быть нарисована вручную.

В Windows Presentation Foundation (WPF) эта ситуация изменилась за счет ввода
модели с совершенно другим устройством. Хотя платформа WPF включает знакомые
стандартные элементы управления, она рисует каждый текст, контур и фон
самостоятельно. В результате WPF может предоставить намного более мощные
средства, которые позволяют изменить визуализацию любой части экранного
содержимого. С помощью этих средств можно изменить стиль обычных элементов
управления, таких как кнопки, часто даже без написания кода. Кроме того, можно
применять трансформации объектов для вращения, растяжения, масштабирования и
сдвига любой части пользовательского интерфейса, и даже использовать встроенную
систему анимации WPF, чтобы делать все это прямо на глазах пользователя.

Графические подсистемы компьютеров продолжали совершенствоваться и дешеветь,
ожидания потребителей росли, но до появления WPF проблеме сложности построения
выразительных пользовательских интерфейсов не уделяли должного внимания.
Некоторые разработчики самостоятельно брались за ее решение, стремясь сделать
свои приложения и элементы управления более привлекательными. Простым примером
тут является использование растровых изображений вместо стандартных кнопок.
Однако мало того что подобные нестандартные решения было трудно реализовывать,
они еще зачастую оказывались ненадежными. Основанные на них приложения не всегда
доступны людям с ограниченными возможностями, плохо адаптируются к высокому
разрешению и имеют другие визуальные огрехи.

В Microsoft разработали один обходной путь для преодоления ограничений, присущих
библиотекам User32 и GDI/GDI+. Этим путем является DirectX. Главной его целью
была скорость, и потому Microsoft тесно сотрудничала с производителями
видеокарт, чтобы обеспечить для DirectX аппаратную поддержку, необходимую для
отображения сложных текстур, специальных эффектов вроде частичной прозрачности и
трехмерной графики.

> :grey_exclamation: Это наиболее существенное изменение в WPF. Технология WPF —
  это не оболочка для GDI/GDI+. На самом деле это его замена — отдельный
  уровень, работающий через DirectX.

В WPF вся работа по рисованию проходит через конвейер DirectX. В результате даже
самые заурядные бизнес-приложения могут использовать богатые эффекты вроде
прозрачности и сглаживания. Также получается выигрыш от аппаратного ускорения, и
это означает, что DirectX передает как можно больше работы узлу обработки
графики (graphics processing unit — GPU), который представляет собой отдельный
процессор на видеокарте.

> :grey_exclamation: Технология DirectX более эффективна, поскольку оперирует
  высокоуровневыми конструкциями вроде текстур и градиентов, которые могут
  отображаться непосредственно видеокартой. Компонент GDI/GDH- на это не
  способен, поэтому ему приходится преобразовывать их в инструкции рисования
  пикселей, и потому отображение проходит намного медленнее даже на современных
  видеокартах.

## Основные возможности, которые предоставляет WPF

* **Веб-подобная модель компоновки.** Вместо того чтобы фиксировать элементы
  управления на месте с определенными координатами, WPF поддерживает гибкий
  поток, размещающий элементы управления на основе их содержимого. В результате
  получается пользовательский интерфейс, который может быть адаптирован для
  отображения высоко динамичного содержимого или к разным языкам.

* **Богатая модель рисования.** Вместо рисования пикселей в WPF вы имеете дело с
  примитивами — базовыми фигурами, блоками текста и прочими графическими
  ингредиентами. Кроме того, доступны такие новые средства, как действительно
  прозрачные элементы управления, возможность укладывания друг на друга
  множества уровней с разной степенью прозрачности, а также встроенная поддержка
  трехмерной графики.

* **Развитая текстовая модель.** После многих лет нестандартной обработки текстов
  WPF наконец-то предоставляет Windows-приложениям возможность отображения
  расширенного стилизованного текста в любом месте пользовательского интерфейса.
  И если нужно отображать значительные объемы текста, для повышения
  читабельности можно воспользоваться развитыми средствами отображения
  документов, такими как переносы, разбиение на колонки и выравнивание.

* **Анимация как первоклассная программная концепция.** В WPF нет необходимости
  использовать таймер для того, чтобы заставить форму перерисовать себя. Вместо
  этого доступна анимация — неотъемлемая часть платформы. Анимация определяется
  декларативными дескрипторами, и WPF запускает ее в действие автоматически.

* **Стили и шаблоны.** Стили позволяют стандартизировать форматирование и
  многократно использовать его по всему приложению. Шаблоны дают возможность
  изменить способ отображения элементов, даже таких основополагающих, как
  кнопки. Построение интерфейса с обложками еще никогда не было таким простым.

* **Команды.** Большинству пользователей известно, что не имеет значения, откуда они
  инициируют команду открытия (Open) — через меню или панель инструментов;
  конечный результат один и тот же. Теперь эта абстракция доступна коду — можно
  определять команды приложения в одном месте и привязывать их к множеству
  элементов управления.

* **Декларативный пользовательский интерфейс.** Хотя можно конструировать окно WPF в
  коде, в Visual Studio используется другой подход. Содержимое каждого окна
  сериализуется в виде XML-дескрипторов в документе XAML. Преимущество состоит в
  том, что пользовательский интерфейс полностью отделяется от кода, и дизайнеры
  графики могут использовать профессиональные инструменты для редактирования
  файлы XAML, улучшая внешний вид всего приложения. (XAML — это сокращение от
  Extensible Application Markup Language.

* **Широкая интеграция.** До WPF разработчикам в Windows, которые хотели
  использовать одновременно 3D-графику, видео, речь и форматированные документы
  в дополнение к обычной двумерной графике и элементам управления, приходилось
  изучать несколько независимых технологий, плохо совместимых между собой и не
  имеющих встроенных средств сопряжения. А в WPF все это входит в состав
  внутренне согласованной модели программирования, поддерживающей композицию и
  визуализацию разнородных элементов.

* **Независимость от разрешающей способности.** Благодаря тому, что WPF
  использует векторную графику, графические элементы выглядат одинаково хорошо
  на любых возможных разрешениях экранов.

* **Аппаратное ускорение.** Поскольку WPF основана на технологии Direct3D, то
  все содержимое в WPF-приложении, будь то двумерная или трехмерная графика,
  изображения или текст, преобразуется в трехмерные треугольники, текстуры и
  другие объекты Direct3D, а потом отрисовывается аппаратной графической
  подсистемой компьютера. Таким образом, WPF-приложения задействуют все
  возможности аппаратного ускорения графики, что позволяет добиться более
  качественного изображения и одновременно повысить производительность
  (поскольку часть работы перекладывается с центральных процессоров на
  графические).

* **Богатые возможности композиции и настройки.** В WPF элементы управления
  могут сочетаться немыслимыми ранее способами. Можно создать комбинированный
  список, содержащий анимированные кнопки, или меню, состоящее из видеоклипов!
  Конечно, сама мысль о таком интерфейсе может привести в ужас, но важно то, что
  для оформления элемента способом, о котором его автор и не помышлял, не
  понадобится писать никакой код (и в этом коренное отличие от
  предшествующих технологий, где отрисовка элементов жестко задавалась
  создателем кода).

# Архитектура WPF

Технология WPF использует многоуровневую архитектуру. На вершине ваше приложение
взаимодействует с высокоуровневым набором служб, которые полностью написаны на
управляемом коде С#. Действительная работа по трансляции объектов .NET в
текстуры и треугольники Direct3D происходит "за кулисами", с использованием
низкоуровневого неуправляемого компонента по имени `milcore.dll`. Библиотека
`milcore.dll` реализована в неуправляемом коде потому, что ей требуется тесная
интеграция с Direct3D, и вдобавок для нее чрезвычайно важна производительность.

![Архитектура WPF](.Net/Lectures/images/architecture.png?raw=true)

Ниже описаны ключевые компоненты, присутствующие на рисунке:

* **PresentationFramework.dll** содержит типы WPF верхнего уровня, включая те,
  что представляют окна, панели и прочие виды элементов управления. Также он
  реализует высокоуровневые программные абстракции, такие как стили. Большинство
  классов, которые вы будете использовать, находятся непосредственно в этой
  сборке.

* **PresentationCore.dll** содержит базовые типы, такие как `UIElement` и
  `Visual`, от которых унаследованы все фигуры и элементы управления. Если вам
  не нужен полный уровень абстракции окон и элементов управления, можете
  опуститься ниже, на этот уровень, и продолжать пользоваться преимуществами
  механизма визуализации WPF.

* **WindowsBase.dll** содержит еще более базовые ингредиенты, которые
  потенциально могут применяться вне WPF, такие как Dispatcher Object и
  Dependency Object, поддерживающие механизм свойств зависимости (эта тема будет
  детально рассмотрена в главе 4).

* **milcore.dll** — ядро системы визуализации WPF и фундамент уровня медиа-
  интеграции (Media Integration Layer — MIL). Его составной механизм транслирует
  визуальные элементы в треугольники и текстуры, которых ожидает Direct3D. Хотя
  milcore.dll считается частью WPF, это также важнейший компонент операционных
  систем Windows Vista и Windows 7. В действительности DWM (Desktop Window
  Manager — диспетчер окон рабочего стола) использует milcore.dll для
  отображения рабочего стола.

* **WindowsCodecs.dll** — низкоуровневый API-интерфейс, обеспечивающий поддержку
  изображений (например, обработку, отображение и масштабирование растровых
  изображений и файлов JPEG).

* **Direct3D** — низкоуровневый API-интерфейс, через который визуализируется вся
  графика в WPF.

* **User32** используется для определения того, какое место на экране к какой
  программе относится. В результате он по-прежнему вовлечен в WPF, но не
  участвует в визуализации распространенных элементов управления.

## Общая иерархия классов WPF

На рисунке показан базовый набор некоторых ключевых ветвей иерархии классов.

> :grey_exclamation: Основные пространства имен WPF начинаются в System.Windows
  (например, `System.Windows`, `System.Windows.Controls` и
  `System.Windows.Media`). Единственным исключением являются пространства имен,
  начинающиеся с System.Windows.Forms, которые относятся к инструментам Windows
  Forms.

![Иерархия классов WPF](.Net/Lectures/images/class-hierarchy.gif?raw=true)

* **System.Threading.DispatcherObject** Приложения WPF используют знакомую
  однопоточную модель (single-thread affinity — STA), а это означает, что весь
  пользовательский интерфейс принадлежит единственному потоку. Взаимодействовать
  с элементами пользовательского интерфейса из других потоков небезопасно. Чтобы
  содействовать работе этой модели, каждое WPF-приложение управляется
  диспетчером, координирующим сообщения (появляющиеся в результате клавиатурного
  ввода, перемещений курсора мыши и таких процессов платформы, как компоновка).
  Будучи унаследованным от `DispatcherObject`, каждый элемент пользовательского
  интерфейса может удостовериться, выполняется ли код в правильном потоке, и
  обратиться к диспетчеру, чтобы направить код в поток пользовательского
  интерфейса.

* **System.Windows.DependencyObject** В WPF центральный путь взаимодействия с
  экранными элементами пролегает через свойства. На ранней стадии цикла
  проектирования архитекторы WPF решили создать более мощную модель свойств,
  которая положена в основу таких средств, как уведомления об изменениях,
  наследуемые значения по умолчанию и более экономичное хранилище свойств.
  Конечным результатом стало средство свойств зависимости (dependency property).
  За счет наследования от `DependencyObject`, классы WPF получают поддержку
  свойств зависимости.

* **System.Windows.Media.Visual** Каждый элемент, появляющийся в WPF, в основе
  своей является Visual. Класс Visual можно воспринимать как единственный объект
  рисования, инкапсулирующий в себе инструкции рисования, дополнительные
  подробности рисования (наподобие отсечения, прозрачности и настроек
  трансформации) и базовую функциональность (вроде проверки попадания). Класс
  Visual также обеспечивает связь между управляемыми библиотеками WPF и сборкой
  `milcore.dll`, которая визуализирует отображение. Любой класс, унаследованный
  от Visual, обладает способностью отображаться в окне.

* **System.Windows.UIElement** Класс `UIElement` добавляет поддержку таких
  сущностей WPF, как компоновка (layout), ввод (input), фокус (focus) и события
  (events) — все, что команда разработчиков WPF называет аббревиатурой LIFE.
  Например, именно здесь определен двухшаговый процесс измерения и организации
  компоновки. Здесь же щелчки кнопками мыши и нажатия клавиш трансформируются в
  более удобные события, такие как `MouseEnter`. Как и со свойствами, WPF
  реализует расширенную систему передачи событий, именуемую маршрутизируемыми
  событиями (routed events).

* **System.Windows.FrameworkElement** Класс `FrameworkElement` — конечный пункт
  в центральном дереве наследования WPF. Он реализует некоторые члены, которые
  просто определены в `UIElement`. Например, `UIElement` устанавливает фундамент
  для системы компоновки WPF, но `FrameworkElement` включает ключевые свойства
  (вроде `HorizontalAlignment` и `Margin`), которые поддерживают его.
  `UIElement` также добавляет поддержку привязки данных, анимации и стилей — все
  они являются центральными средствами.

* **System.Windows.Shapes.Shape** От этого класса наследуются базовые фигуры,
  такие как `Rectangle`, `Polygon`, `Ellipse`, `Line` и `Path`. Эти фигуры могут
  использоваться наряду с более традиционными графическими элементами Windows
  вроде кнопок и текстовых полей.

* **System.Windows.Controls.Control** Элемент управления (control) — это
  элемент, который может взаимодействовать с пользователем. К нему очевидным
  образом относятся такие классы, как `Text Box`, `Button` и `ListBox`. Класс
  `Control` добавляет дополнительные свойства для установки шрифта, а также
  цветов переднего плана и фона. Но наиболее интересная деталь, которую он
  предоставляет — это поддержка шаблонов, которая позволяет заменять стандартный
  внешний вид элемента управления собственным рисованием.

* **System.Windows.Controls.ContentControl** Это базовый класс для всех
  элементов управления, которые имеют отдельный фрагмент содержимого. Сюда
  относится все — от скромной метки `Label` до окна `Window`. Наиболее
  впечатляющая часть этой модели заключается в том, что единственный фрагмент
  содержимого может быть чем угодно — от обычной строки до панели компоновки,
  содержащей комбинацию других фигур и элементов управления.

* **System.Windows.Controls.ItemsControl** Это базовый класс для всех элементов
  управления, которые отображают коллекцию каких-то единиц информации, вроде
  `ListBox` и `TreeView`. Списочный элемент управления замечательно гибок;
  например, используя встроенные средства класса `ItemsControl`, можно
  трансформировать обычный `ListBox` в список переключателей, список флажков,
  упорядоченный набор картинок или комбинацию совершенно разных элементов по
  своему выбору.

* **System.Windows.Controls.Panel** Это базовый класс для всех контейнеров
  компоновки — элементов, которые содержат в себе один или более дочерних
  элементов и упорядочивают их в соответствии с определенными правилами
  компоновки. Эти контейнеры образуют фундамент системы компоновки WPF, и их
  использование — ключ к упорядочиванию содержимого наиболее привлекательным и
  гибким способом.