=== chapter_2 ===
<pause>
 ->part_2_1

=== part_2_1 ===
#started_bg home_evening
<pause>
..: Твое сердце ухнуло вниз.
Карл (surprise): Это что, я тебя спрашиваю?
..: Разувшись и бросив вещи у порога, он прошел мимо тебя к ноутбуку.
..: Ты стояла как вкопанная, пока за твоей спиной не раздался его насмешливый голос.
Карл (smile): Не иначе собралась в модели?
ГГ (sad): …
..: Грубым движением Карл потрепал тебя за плечо.
Карл (evil): Что молчишь? Язык проглотила?

{professionalism > scandal:
    #info Путь профессионализма
    ГГ (dream): Да.
    Карл (surprise): Что да?
    ГГ (evil): Да, я собралась в модели.
    ..: От его колючего злого взгляда хотелось спрятаться, но ты только расправила плечи.
    Карл (laugh): Кто? Ты? Не смеши меня.
    ГГ (base): Как ответить?
    
        + [Почему ты смеешься?]
            ..: Карл удивленно вскинул брови на твой холодный тон.
            Карл (surprise): Потому что какая из тебя модель? Ты себя видела?
            ГГ (evil): Видела.
            -> part_2_2

        + [Посмотрим, кто будет смеяться последним.]
            #info Это повлияло на отношения с Карлом.
            ~ respect_Karl = respect_Karl - 1
            ..: Такого удивления на лице Карла ты еще не видела.
            ..: Ты и сама не ожидала от себя такого ответа.
            Карл (evil): Что ты сказала?
            -> part_2_2

        + [И что здесь смешного?]
            ..: Карл пожал плечами, ухмыляясь.
            Карл (smile): Таких в модели не берут.
            ..: Он кивнул в сторону ноутбука, где все еще был открыт сайт с моделями агентства.
            Карл (laugh): Где ты, и где они.
            -> part_2_2
        
- else:
    #info Путь скандала
    ГГ (sad): «Как может быть так одиноко рядом с самым близким человеком?»
    ГГ (dream): Вот и собралась. Тебе-то что?
    ..: Карл оценивающе оглядел тебя. 
    ..: От его взгляда тебе стало не по себе, но ты не подала виду.
    Карл (smile): И с чего ты взяла, что ты там кому-то сдалась?
    Карл (laugh): Думаешь, тебе повезет?
    ..: Его надменная ухмылка заставила тебя сжать кулаки.
    ГГ (base): Как ответить?
    
        + [Я всегда была везучей.]
            ..: Его брови взлетели вверх.
            Карл (smile): То-то я и смотрю, везучая какая. В кофейне полы моешь.
            ГГ (surprise): …
            ГГ (evil): «Знает ведь, как меня это гложет…»
            -> part_2_2

        + [Мне везет, в отличие от тебя.]
            #info Это повлияло на отношения с Карлом.
            ~ respect_Karl = respect_Karl - 1
            ..: Его лицо резко ожесточилось.
            Карл (evil): В каком это смысле?
            ГГ (base): В прямом.
            ГГ (flirt): Меня хотя бы не увольняли за плохую работу.
            ..: Карл сузил глаза, наблюдая за тобой, но ты смело встретила его взгляд.
            ГГ (base): Что? Язык проглотил?
            ..: Подумав, он ядовито плюнул в тебя словами.
            Карл (evil): Ты такая же неудачница, ничем не лучше.
            -> part_2_2
}

=== part_2_2 ===
ГГ (flirt): Скаут этого агентства пригласил меня работать у них.
..: Одна бровь Карла медленно поползла вверх.
Карл (laugh): Во сне?
ГГ (base): Нет, увидел меня в кофейне, пока я работала.
Карл (smile): Тебя обдурил какой-то мужик, а ты и рада.
Карл (smile): Надеюсь, все свои деньги ему не всучила?
ГГ (dream): «Да сколько можно издеваться?!»
ГГ (base): Я собираюсь согласиться. И уволиться из кофейни.
..: Карл сразу перестал язвить. Ты физически ощутила исходящую от него агрессию.
Карл (surprise): И чем нам платить за квартиру, пока ты будешь строить из себя модель?
Карл (evil): Не будешь ты на это соглашаться. Я еще не нашел работу.
..: Он подошел к ноутбуку и захлопнул его, давая понять, что разговор окончен.
..: К глазам подступили слезы. Ты покусала щеки изнутри, чтобы не разрыдаться перед ним.
ГГ (base): Я соглашусь.
..: Карл уже уселся у телевизора, вытянув ноги на журнальный столик, и проигнорировал твои слова.
ГГ (evil): Я позвоню прямо сейчас.
Карл (evil): Я же сказал - нет.
..: Предательские слезы брызнули из глаз, ты схватилась за свой телефон.
ГГ (evil): Я тебя не спрашивала!
..: Он раздраженно вскочил с места и подлетел к тебе.
..: Его ладонь сильно сжала твое запястье и он отвел его в сторону, не давая тебе набрать номер.
..: Сколько было ссор, никогда еще Карл не причинял тебе физической боли, поэтому ты растерялась.
ГГ (base): Что мне делать?  

    + [отреагировать спокойно]
        ~ alter(professionalism, 1)
        ..: Ты попыталась звучать как можно спокойнее.
        ГГ (base): Отпусти.
        ГГ (base): Ты делаешь мне больно.
        Карл (base): Обещай мне, что не будешь связываться с этим человеком.
        ..: Вы уставились друг на друга и ты не могла поверить в то, что это происходит с тобой.
        -> part_2_3

    + [timer испугаться]
        ГГ (surprise): «Почему я не могу шевельнуться?»
        ..: Все мышцы одеревенели, ты не могла заставить себя даже дернуться.
        ..: Карл довольно ухмыльнулся в ответ на твой испуганный взгляд.
        Карл (base): А теперь скажи, что ты не станешь звонить этому человеку.
        ГГ (sad): …
        -> part_2_3

     + [попытаться выдернуть руку]
        ~ alter(scandal, 1)
        ..: Ты резко дернула руку вниз, но хватка стала крепче.
        ..: Тяжело дыша, ты продолжала неистово биться.
        Карл (surprise): Да успокойся ты!
        ..: Он дернул тебя, приводя в чувство.
        Карл (base): Если ты меня любишь, ты не станешь этого делать.
        ГГ (dream): «Чего он так уперся?»
        ГГ (base): Я люблю тебя, но буду делать то, что посчитаю нужным.
        -> part_2_3
    
=== part_2_3 ===
ГГ (base): Я не могу ничего обещать.
ГГ (dream): Это моя жизнь и мое решение.
..: Дальше произошло то, чего ты не могла представить даже в самом страшном сне.
#bg blink
<pause>
..: От приложенной силы ты потеряла равновесие и зашаталась на месте, но вовремя облокотилась на комод позади себя.
..: Осознание накрыло тебя только через несколько секунд, когда в щеке вспыхнула яркая резкая боль.
ГГ (sad): «В голове звенит…»
..: Ты приложила пальцы к горячей коже.
ГГ (surprise): «Он… меня ударил?…»
Карл (base): Так понятнее?
ГГ (surprise): Что?
Карл (evil): Так тебе понятнее, что ты не одна тут можешь принимать решения?
..: У тебя была полная дезориентация от случившегося, а тело трясло, как в лихорадке.
ГГ (surprise): Надо…

     + [d15 попытаться поговорить с ним]
        ~ alter(professionalism, 1)
        ..: Ты пыталась думать быстрее, но тебя так трясло, что мысли едва собирались в кучу.
        ~ alter(scandal, 1)
        ГГ (base): Ты только что ударил меня, Карл.
        Карл (base): …
        ГГ (evil): Ты понимаешь, что ты сделал?
        Карл (evil): Замолчи.
        Карл (evil): Иначе я сделаю это еще раз.
        ..: Ты услышала отчаяние в его словах.
        ГГ (dream): «Он сам в шоке, но делает вид, что все под контролем».
        ГГ (base): Карл, ты больше ко мне не прикоснешься.
        Карл (surprise): Я…
        ..: Ты вскинула голову и посмотрела ему прямо в глаза, пряча свой страх за маской уверенности.
        ГГ (evil): Не станешь.
        Карл (evil): Ты…
        ГГ (evil): Дай мне сказать!
        ..: И неожиданно Карл замолчал, услышав твой непривычно жесткий тон.
        ГГ (dream): Сколько месяцев уже мы еле сводим концы с концами на мою зарплату?
        ГГ (evil): И вместо того, чтобы найти работу и поддержать меня, ты решаешь поднять на меня руку!
        ГГ (sad): Немыслимо.
        Карл (surprise): Но…
        ГГ (evil): Я закончу.
        ГГ (sad): Так не может больше продолжаться. Мы расстаемся.
        ГГ (base): Сейчас.
        ..: Ты сделала несколько шагов назад, еще несколько.
        ..: Глядя друг на друга, вы словно молча прощались.
        Карл (base): …
        ГГ (sad): …
        ..: Неожиданно раздался его сухой бесцветный голос.
        Карл (base): Ты вернешься?
        ГГ (evil): Тебе должно быть стыдно.
        ..: Ты взяла свою сумку и вышла из квартиры.
        -> part_2_4

    + [притвориться, что поняла]
        ~ alter(professionalism, 1)
        ..: Ты растерянно кивнула.
        Карл (smile): Так-то лучше. Забудь эти бредни.
        ..: Он снова уселся на диван, закинул руки за голову и вперился в телевизор.
        ..: Затем едва различимо пробурчал под нос, но ты все-таки услышала.
        Карл (laugh): Недомоделька.
        ..: Отойдя от шока, ты кое-что вспомнила
        ГГ (dream): «Я же купила пиво и оно лежит в холодильнике».
        ГГ (dream): «Но Карл об этом еще не знает».
        ..: Ты подошла к нему со спины и как можно мягче положила ладони на его плечи, легко массируя.
        ГГ (base): Хочешь, я схожу в магазин и куплю тебе пива?
        ..: Кажется, твои слова не вызвали у него и тени подозрения.
        Карл (smile): Вот это другое дело. Отличная идея. 
        ..: Во рту стало неприятно сухо, ты едва ворочала языком.
        ГГ (smile): Хорошо, я быстро.
        -> part_2_4

    + [бежать]
        ~ alter(scandal, 1)
        ГГ (evil): «Как он посмел вообще».
        Карл (surprise): Ты больной!
        ..: Ты пыталась понять, как тебе быстрее покинуть дом, соображая изо всех сил.
        ..: Карл вдруг ощутимо толкнул тебя в плечо, ты снова уперлась в комод.
        ГГ (evil): Прекрати!
        Карл (smile): А то что?
        ..: По его лицу ты поняла, что он вот-вот поднимет руку на тебя еще раз.
        ..: Сердце билось оглушительно, у тебя дрожали руки от захлестнувшей плохо контролируемой злости.
        ..: Внезапно тебя осенило.
        ГГ (dream): «Его надо вырубить. И бежать, как можно скорее.»
        Карл (base): Посмотри на меня, (имя гг).
        Карл (evil): И скажи, что ты не будешь увольняться из кофейни.
        ..: Почти взглянув на него, ты вдруг бросилась к вазе на обеденном столе.
        ..: У вас была студия и этот марш-бросок был довольно коротким.
        Карл (evil): Эй!
        ..: Прежде, чем он успел схватить тебя, ты уже опустила вазу ему на голову.
        ..: Раздался глухой удар и звук бьющегося стекла.
        Карл (surprise): …
        ..: Еще мгновение назад готовый помешать тебе, теперь он обмяк и упал на колени, а затем завалился набок.
        ..: Дрожащими руками ты проверила его бьющееся сердце.
        ГГ (sad): Прости…
        ..: Убедившись, что он только отключился, ты бросилась прочь из дома.
        -> part_2_4

=== part_2_4 ===
#bg street_night
<pause>
..: Ночной город встретил тебя холодным воздухом, от которого тебя пробрало до мурашек.
ГГ (sad): Как же сильно бьется сердце. Еще и голова трещит.
ГГ (sad): И куда мне идти?
..: Ответить тебе было некому.
..: Ты проверила взятую с собой сумку, с облегчением нашла в ней паспорт.
ГГ (evil): Я не хочу возвращаться домой.
ГГ (dream): Домой?
ГГ (sad): Это больше не мой дом.
..: Пошарив по карманам одежды, ты наткнулась на ту самую визитку раздора.
ГГ (sad): Кажется, мне придется позвонить ему сейчас. Интересно, ответит ли?
ГГ (dream): Или лучше позвонить родным?
..: Кому позвонить?

- (who)
    * [родителям]
        ГГ (dream): Нет, зачем мне звонить незнакомому человеку со своими проблемами.
        ..: Ты набрала номер мамы и ждала ее ответа.
        Мама (тень): Привет, доча!
        ..: Твое сердце сжалось от звука родного голоса.
        ГГ (sad): «Я не могу сказать ей».
        ГГ (sad): Привет, мам.
        Мама (тень): У тебя все нормально?
        ГГ (dream): Да. Да, все хорошо. Я…
        ..: Ты пнула камешек на дороге, подбирая слова.
        ГГ (base): Просто соскучилась, хотела тебя услышать.
        ..: На том конце послышался радостный вздох.
        Мама (тень): У нас тоже все хорошо. Как твоя учеба?
        ГГ (surprise): А… Отлично. Ладно, мам, не могу долго говорить, я тебе перезвоню.
        ..: Испугавшись еще вопросов про учебу, ты бросила трубку.
        ..: Кому позвонить?
    -> who
    
    * [Мартину]
        -> part_2_5
    
=== part_2_5 ===
..: Медленно бредя вдоль улицы, ты слушала гудки.
..: Вдруг они сменились чужим голосом.
Мартин (none): Алло?
..: Ты помедлила, осознав, что не знаешь, как начать разговор.
Мартин (none): Кто это?
ГГ (base): Это (имя гг). Вы дали мне свою визитку сегодня в кофейне.
Мартин (none): Да-да, помню.
Мартин (none): Что-то случилось? Уже довольно поздно.
..: Ты поняла, что вот-вот заплачешь, и прикусила губу, прежде чем ответить.
ГГ (sad): Мартин, я… у меня…
..: Слова не складывались в предложения, ты не успела заглушить собственный всхлип.
..: Слезы полились сами собой и ты нервно вытирала их, размазывая по лицу.
Мартин (none): (имя гг), вы плачете?
ГГ (sad): Я… нет…
..: Ты никак не могла совладать с обрушившимися на тебя эмоциями.
Мартин (none): Я слышу, что да. Давайте поступим следующим образом.
..: Его строгий голос вселял в тебя какое-то подобие надежды.
Мартин (none): Вызовите себе такси и приезжайте по адресу, который я пришлю вам в мессенджере.
ГГ (sad): Хорошо. Спасибо.

{is_tell_true_Martin: 
    ~ respect_Martin = respect_Martin + 1
    ..: Прежде чем попрощаться, он добавил.
    Мартин (none): Не плачьте. Мы со всем разберемся.
    ..: От последнего предложения тебя снова накрыла волна мурашек.
}

..: Положив трубку, ты дождалась сообщения.
ГГ (dream): Это довольно далеко отсюда.
..: Ты вызвала такси и поехала по адресу, не зная, чего там ожидать. 
#bg taxi_night
<pause>
..: По дороге ты то и дело возвращалась к мыслям…

- (who)
    * [о Карле]
        ГГ (dream): Неужели я действительно хочу уйти от него?
        ГГ (sad): И все-таки закончить нашу историю?
        ..: Ты всматривалась в ночные этюды проплывающих мимо улиц.
        ..: Чувство правильного решения вызывало у тебя улыбку сквозь слезы.
        ГГ (dream): Все равно придется еще поговорить с ним, ведь надо будет забрать вещи.
        ..: Задумавшись о своих отношениях, ты пришла к неутешительному выводу.
        ГГ (sad): Кажется, я уже давно не люблю его.
        ГГ (sad): Такое ощущение, что последний год я спала и наконец-то проснулась.

    * [о прошлом]
        ..: Тяжело вздохнув, ты вырисовывала пальцем по стеклу одной тебе понятные узоры.
        ГГ (sad): Отношения с Карлом были такими прекрасными в школе.
        ГГ (dream): Но стоило нам закончить учебу, как его словно подменили.
        ..: Воспоминания годичной давности вызывали у тебя непреодолимую тоску на душе.
        ГГ (surprise): А когда я объявила о поступлении в университет в другом городе?
        ГГ (dream): Сколько было ссор из-за этого, но как итог — мы переехали вместе.
        ГГ (sad): А потом его увольнение, мое отчисление из-за неуспеваемости, попытки наскрести деньги на жизнь.
        ..: Ты снова вздохнула, понимая, как все это выглядит со стороны.
        ГГ (evil): Как глупо я трачу те деньги, что мне присылают родители.
        ГГ (sad): Стыдно сказать им, но однажды придется.

    * [о будущем]
        ..: Тебя охватило волнение от одной мысли о том, что ты едешь к незнакомцу из-за случившегося с Карлом.
        ГГ (surprise): Почему он вообще решил мне помочь?
        ГГ (dream): Неужели настолько хочет заполучить мою внешность в агентство, что готов нянчиться?
        ..: Ты задумалась о своем возможном будущем.
        ГГ (dream): Если у меня все получится, может я смогу устроить свою жизнь?
        ГГ (surprise): Купить себе квартиру, как мечтаю, помогать родителям?
        ..: Достав телефон, ты поискала в интернете профили известных моделей.
        ..: Их невероятные жизни, вечеринки, красивые модельные работы заставили тебя нервно сглотнуть и убрать телефон обратно в карман.
        ГГ (sad): Нет, до такого уровня мне не допрыгнуть.
        ГГ (base): Но выжать максимум можно попробовать.

    * {loop} -> done
    - (loop)
    {..: По дороге ты то и дело возвращалась к мыслям…-> who|..: По дороге ты то и дело возвращалась к мыслям…->who|}
    - (done)
    -> part_2_6

=== part_2_6 ===
..: Погрузившись в свои мысли, ты не сразу поняла, что машина остановилась.
..: За окном был бизнес-квартал, где тебе еще не приходилось бывать.
ГГ (base): Как же неудобно перед ним, зачем я приехала сюда?
ГГ (sad): Отступать некуда.
#bg street_night
<pause>
..: Расплатившись с таксистом, ты вышла из машины и замерла перед дверью подъезда.
ГГ (base): Ладно, успокоилась. Пошла.
ГГ (dream): Но надо быть начеку, все-таки незнакомый человек.
..: Поднявшись на нужный этаж, ты позвонила в дверной звонок.
..: Мартин не заставил себя долго ждать.
Мартин (base): Привет.
..: От него исходила аура спокойствия.
ГГ (sad): …
..: Руки сами потянулись потереть покрасневшие глаза.
..: Ты почувствовала как чужие ладони осторожно взяли тебя за запястья и отвели руки от лица.
Мартин (base): Не стоит, глаза потом будут болеть.
Мартин (smile): Проходите.
#bg home_Martin_night
<pause>
..: Растерявшись от неожиданного прикосновения, ты послушно зашла.
..: И только после закрывшейся за спиной дверью твои плечи смогли расслабиться и опуститься.
ГГ (sad): Простите еще раз, что я вас потревожила.
Мартин (base): Ничего страшного. Вы мне вовсе не помешали.
Мартин (base): Присаживайтесь. Будете чай?
ГГ (base): Пожалуй…

    + [да, буду чай]
        Мартин (smile): Давайте я заварю для вас что-нибудь успокаивающее.
        ..: Ты вымучила улыбку.
        ГГ (smile): Буду премного благодарна.
        -> part_2_7

    + [нет, лучше воды]
        Мартин (surprise): Точно? Хороший чай может успокоить нервы.
        ГГ (base): И все же я предпочту стакан воды.
        ГГ (smile): Не люблю пить чай на ночь.
        Мартин (base): Из-за кофеина?
        ГГ (surprise): В чае есть кофеин?
        Мартин (smile): …
        -> part_2_7

=== part_2_7 ===
..: Вы сели за обеденный стол и ты вновь спрятала лицо в ладони.
..: Он попытался поймать твой взгляд, затем мягко поинтересовался.
Мартин (base): Расскажете, что случилось?
..: Ты обняла себя руками и сосредоточилась на одной точке на столе.
ГГ (sad): Это все мой парень…
..: Ты вновь сжалась, вспомнив вашу ссору, и это не ускользнуло от внимательного взгляда Мартина.
ГГ (sad): Он увидел открытый сайт вашего агентства, начал возмущаться…
ГГ (evil): Сказал, что мне не светит модельная работа и не надо мне туда лезть.
ГГ (sad): Требовал, чтобы я выкинула это из головы и продолжала работать в кофейне.
ГГ (dream): «Стоит ли говорить, что было дальше?»

    + [скажу правду]
        #info Мартин ценит твою искренность
        ГГ (surprise): А потом замахнулся и … дал пощечину.
        ..: Мартин сощурился, услышав это слово, но ничего не сказал.
        ГГ (sad): Он так никогда не поступал. Я даже не знала, что он на это способен.
        ГГ (sad): Мне…
        ГГ (sad): Стало страшно.
        ГГ (base): Пришлось срочно бежать. Хоть куда-то.
        ..: Ты прикусила язык, чтобы не сказать лишнего.
        Мартин (evil): То, что он сделал, ужасно. И совершенно недопустимо.
        ..: Его ладонь накрыла твою.
        ..: В этом жесте не было романтики, скорее искреннее желание поддержать тебя и успокоить.
        Мартин (base): Вы не виноваты в случившемся.
        ГГ (surprise): С…спасибо.
        ..: Он тут же отпустил твою руку.
        ГГ (dream_2): «Почему я хочу, чтобы он ее вернул?»
        -> part_2_8

    + [скрою правду]
        #info Это скажется на отношении Мартина к тебе в будущем
        ГГ (sad): И… я расстроилась.
        ..: Твои уши краснели, так как ты не привыкла врать.
        ГГ (dream): Решила уйти на улицу и подумать…
        Мартин (base): И поэтому позвонили мне в слезах?
        ..: Тебе было некуда деваться от его спокойно заданного вопроса.
        ГГ (surprise): Я… очень эмоциональная. Все принимаю близко к сердцу.
        ..: Ты отвела глаза, проклиная себя за решение не говорить все до конца.
        ..: Взглянув на Мартина исподлобья, ты поняла, что он тебе не поверил.
        -> part_2_8

=== part_2_8 ===
Мартин (base): Что ж… можно на ты?
ГГ (surprise): А-а, да. Конечно.
Мартин (base): У тебя выдался тяжелый вечер…
..: Решив, что он сейчас тебя прогонит, ты затараторила на эмоциях.
ГГ (surprise): Я вам позвонила, потому что я хочу у вас работать.
ГГ (surprise): Вы ведь сделали мне предложение? 
ГГ (smile): Я согласна. 
Мартин (surprise): Рад слышать, но сейчас это не самое важное.
ГГ (dream): …
Мартин (base): Думаю, ты уже устала.
Мартин (base): У меня есть гостевая комната.
ГГ (surprise): Я…
..: Ты вдруг испугалась его предложения и окончательно растерялась.
Мартин (base): Все нормально, вряд ли ты можешь сейчас вернуться домой.
Мартин (base): Ты никак меня этим не побеспокоишь.
Мартин (smile): Я буду рад помочь.
ГГ (dream): «Насколько вообще адекватно на это соглашаться? Мы же едва знакомы…»
Мартин (base): Или я могу предложить тебе остановиться в отеле за углом.
Мартин (base): Сейчас не сезон и там точно будет свободный номер.
ГГ (sad): «Что за отель там может быть в таком дорогущем районе?»
…: Как поступить?

    + [выбрать отель]
        ~ alter(professionalism, 1)
        ГГ (sad): Лучше я не буду тебя стеснять. Мне и так неловко.
        Мартин (surprise): Ты уверена?
        ГГ (base): Да.
        Мартин (base): Как скажешь. Я позвоню в отель.
        ..: Пока он разговаривал, ты отвлеклась на разглядывание кухни, которая выглядела так, словно Мартин редко ей пользовался.
        ..: И из-за этого все прослушала.
        Мартин (base): Я понял. Благодарю. До свидания. 
        ГГ (base): Ну что там?
        Мартин (sad): Остались только дорогие номера. 
        ..: От услышанной стоимости ты выпучила глаза и нервно усмехнулась. 
        ..: Вскинув руку, он проверил время на наручных часах.
        ГГ (smile): Проверяешь время по старинке, пока держишь в руках телефон?
        Мартин (smile): …
        Мартин (base): Увы, предлагаю все-таки остаться у меня.
        Мартин (base): Мы потратим больше сил на поиск отеля, уже достаточно поздно.
        ..: Ты пожала плечами, решив, что на отель все равно не хотелось тратить деньги.
        ГГ (smile): Часто ты так заманиваешь симпатичных девушек домой?
        Мартин (flirt): Ты первая.
        ГГ (flirt): «Как ему все-таки идет улыбка».
        ГГ (wide_smile): Тогда показывай гостевую комнату.
        ГГ (smile): И… спасибо.
        ..: Ты помедлила и добавила.
        ГГ (base): За все.
        Мартин (smile): Пока еще не за что.
        -> part_2_9

    + [остаться]
        ~ alter(scandal, 1)
        ГГ (dream): «У меня нет денег на отель, да и, кажется, ему можно доверять».
        ГГ (smile): Спасибо, я останусь.
        ..: Мартин ободряюще легко улыбнулся одними уголками губ.
        Мартин (smile): Тогда пойду приготовлю спальню.
        ..: Стоило ему встать из-за стола, как ты вдруг схватила его за руку.
        ГГ (surprise): Еще раз спасибо.
        Мартин (smile): Все в порядке.
        -> part_2_9

=== part_2_9 ===
..: Он вышел из кухни и ты осталась одна со своими мыслями.
ГГ (dream): «Почему Карл не звонит, не пишет?»
ГГ (dream): «Неужели ему все равно, где я пропадаю ночью?»
..: Мартин позвал тебя, когда все было готово.
#bg guestroom
<pause>
ГГ (smile): Здесь уютно.
Мартин (base): У меня редко бывают гости, но я стараюсь поддерживать порядок.
Мартин (flirt): Мало ли, что может случиться.
..: От его выразительного взгляда ты покраснела.
Мартин (base): Я буду в гостиной, если что-то понадобится.
ГГ (dream): «Еще и гостиная, сколько же тут комнат».
ГГ (smile): Хорошо.
..: Оставшись одна, ты присела на край застеленной постели.
..: Кулаки сжались на покрывале, тебя снова душили слезы.
ГГ (evil): Соберись. Хватит уже жалеть себя.                           
ГГ (evil): Я приняла правильное решение.
..: Посидев немного в телефоне, ты поняла, что тебе слишком одиноко и хочется с кем-то поговорить.
ГГ (dream): Скучно как-то, а спать не хочется.
ГГ (dream): Интересно, что делает Мартин?
..: Ты встала и приоткрыла дверь, выглянула в коридор.
..: Из гостиной доносилась приятная музыка.
ГГ (dream): Он сказал, я могу обратиться к нему, если мне что-то понадобится.
ГГ (dream): Это включает в себя составить мне компанию?
#bg home_Martin_night
<pause>
..: На цыпочках ты подошла к арке ведущей в гостиную.
..: Мартин сидел спиной к тебе на диване, в его руке ты разглядела бокал с вином.
Мартин (sad): …
..: Лился джаз, под который ты непроизвольно начала кивать головой в такт.
..: Тебе показалось, что Мартин что-то рассматривает в телефоне.
..: Из-за его спины тебе было видно экран и ты…

    + [всмотрелась в него получше]
        ~ alter(scandal, 1)
        ..: Ты напрягла зрение изо всех сил.
        ГГ (surprise): …
        ..: На экране была открыта фотография с изображением семьи.
        ГГ (dream): «Мужской и женский силуэты… рядом кто-то поменьше, ребенок?»
        ГГ (dream): «Зачем смотреть фотографии чьей-то семьи в такое время?»
        ГГ (dream): «Это ужасно, что я подглядываю».
        -> part_2_10

    + [отвела взгляд в сторону]
        ~ alter(professionalism, 1)
        ГГ (dream): Если там что-то личное, мне не стоит в это лезть.
        ГГ (dream): В конце концов, это просто неприлично.
        -> part_2_10

=== part_2_10 ===
..: Ты прокашлялась, привлекая к себе внимание.
Мартин (surprise): О, (имя гг). Не спится?
..: Он тут же выключил телефон и положил его экраном вниз на стол.
ГГ (smile): Да, что-то не могу уснуть. Тревожно.
Мартин (base): Вина?
ГГ (surprise): Чья?
Мартин (smile): …
Мартин (base): Я предлагаю расслабляющий бокал вина перед сном.                          
ГГ (dream): «Боже, какая вина, о чем я думаю».
ГГ (flirt): «Быстро мы перешли от расслабляющего чая к расслабляющему вину».
ГГ (smile): Я не против.
ГГ (dream): «Тебе же завтра на работу. И ты его почти не знаешь!»
..: Мартин налил тебе меньше половины бокала.
..: Ты вдохнула аромат, затем покачала бокал в руке, заставляя вино кружиться в сосуде.
Мартин (surprise): …
..: Ты снова вдохнула аромат, улавливая в нем разные нотки.
ГГ (dream): М-м…

    + [d10 Выдерживалось в бочке?]
        #info Ваши отношения с Мартином улучшились
        Мартин (surprise): Да.
        ГГ (dream): Этот запах кедра ни с чем не спутаешь.
        ГГ (smile): Предпочитаешь Бордо?
        Мартин (base): Иногда. 
        Мартин (smile): Редко встретишь кого-то, кто может оценить хорошее вино по достоинству. 
        ГГ (base): Мой отец увлекался виноделием.
        ..: В глазах Мартина вспыхнула искра интереса.
        Мартин (base): И чем же конкретно он занимался?
        ГГ (dream): Был совладельцем небольшой винодельни во Франции.
        ..: Вы просидели на диване часа полтора, обсуждая вина и будущее виноделия в Европе.
        ..: Алкоголь ударил тебе в голову после второго выпитого бокала.
        Мартин (base): Думаю, теперь точно пора спать.
        Мартин (smile): Спасибо за приятную беседу.
        ГГ (dream): «Никогда не обсуждала с Карлом чего-то подобного».
        ГГ (dream): «Он не особо интересовался моей семьей».
        ГГ (dream): «Мартин совершенно другой…»
        ..: Он потянулся к тебе забрать бокал.
        ГГ (dream): Я хочу…
        VAR is_kiss_you = false
        
        ++ [d15 поцеловать тебя]
            #music sex_SL_LOW
            ~ respect_Martin = respect_Martin + 1
            ~ is_kiss_you = true
            ..: Ты не поверила, что сказала это вслух, и перестала дышать.
            ..: Рука Мартина замерла, так и не дотянувшись до бокала.
            ГГ (dream): «Хочу провалиться сквозь землю».
            Мартин (base): Скорее, ты просто хочешь занять мной свои мысли, чтобы не думать о Карле.
            ..: Ты воинственно отставила вино на стол.
            ГГ (base): Может и так. И что же?
            ..: Алкоголь всегда делал тебя излишне смелой.
            ..: Он громко выдохнул, уводя взгляд в сторону.
            ГГ (surprise): Мартин?
            Мартин (base): Я… обычно не вступаю в отношения со своими моделями.
            Мартин (flirt): Хотя не могу отрицать, что меня к тебе тянет.
            ГГ (surprise): Тогда что не так?
            ..: Мартин грустно улыбнулся, покачивая свой бокал.
            Мартин (base): Иногда мы так хотим приблизиться к солнцу, что опаляем крылья и разбиваемся насмерть.
            ..: Ты непонимающе поморгала, а затем нахмурилась.
            ГГ (evil): Кормишь меня сказкой про Икара?
            Мартин (smile): Легендой.
            ГГ (dream): Легендой.
            ..: Его теплая рука по-дружески легла поверх твоей, но ты все равно нервно сглотнула.
            Мартин (smile): Извини, если ввел тебя в заблуждение.
            Мартин (base): Я не хочу отталкивать тебя, но и не могу ничего предложить.
            ..: Тебе показалось, что он хотел добавить «пока что», но эти слова не прозвучали.
            ..: Взгляд Мартина скользнул от твоего лица к бокалу на столе.
            Мартин (flirt): И лучше не пей так с незнакомцами.
            Мартин (base): Я не самый плохой человек, но в нашем бизнесе это скорее редкость.
            ..: Ты отдернула руку и вспыхнула, почувствовав себя оскорбленной.
            ГГ (evil): Я бы не стала!
            Мартин (base): Я знаю. Просто будь осторожна.
            ..: Поднявшись, он протянул тебе руку и повел к гостевой.
            Мартин (base): Спокойной ночи, (имя гг).
            ..: Мартин вдруг поднес твою руку к своим губам и оставил легкий поцелуй на тыльной стороне.
            #cutscene kiss_scene
            <pause>
            #started_bg home_Martin_night
            <pause>
            ГГ (surprise): Спокойной ночи, Мартин...
            ..: Он ушел в свою спальню и ты проводила его взглядом, пока за ним не закрылась дверь.
            ГГ (surprise): Как удивительно все изменилось…
            ..: Ты улеглась на кровать, уставившись в потолок.
            ..: Из-за алкоголя и неожиданного всплеска храбрости твое сердце билось слишком сильно и сон не шел.
            ..: Но наконец-то веки стали тяжелыми, а тело расслабилось.
            -> part_2_11   
            
        ++ [спать]
            ~ is_kiss_you = false
            Мартин (smile): Я заметил. Пойдем, помогу тебе дойти до комнаты.
            ..: Галантно взяв тебя под руку, Мартин довел тебя до гостевой и попрощался.
            ..: Ты проводила его взглядом, пока за ним не закрылась дверь спальни.
            ГГ (dream): Как удивительно все изменилось…
            ..: Ты легла на кровать и уснула раньше, чем твоя голова коснулась подушки.
            -> part_2_11
        
    + [Вино как вино]
        Мартин (surprise): Не нравится?
        ГГ (base): Мой отец увлекался виноделием, поэтому я вынужденно знаю о нем много, но сама не особо интересуюсь.
        ГГ (dream): Я редко пью алкоголь, но сегодня такой день, что я сделаю исключение.
        Мартин (evil): Хм…
        ..: Его явно расстроило твое равнодушие к вину и Мартин перевел тему.
        ..: Вы просидели на диване какое-то время, обсуждая последние новости в мире.
        ..: Когда повисла пауза, ты решилась сказать то, что лежало на душе.
        ГГ (smile): Спасибо за компанию, Мартин. Мне нужно было с кем-то поговорить.
        Мартин (base): У тебя нет друзей?
        Мартин (surprise): Прости, если это личное.
        ГГ (base): Ничего. Были когда-то, до переезда.
        ..: Ты бросила взгляд на настенные часы и встала с дивана.
        ГГ (base): Я хочу спать. Еще раз спасибо.
        Мартин (smile): И тебе спасибо за компанию.
        Мартин (base): Пойдем, провожу тебя до комнаты.
        ..: Галантно взяв тебя под руку, Мартин довел тебя до гостевой и попрощался.
        ..: Раздевшись, ты легла на кровать и уснула раньше, чем твоя голова коснулась подушки.
        -> part_2_11   

=== part_2_11 ===
..: Тебе снился Карл.
..: В его безумных глазах читалось, как сильно он тебя ненавидит.
..: Его руки все сильнее сжимали твое горло и ты никак не могла вздохнуть.
ГГ (sad): Нет!

~ chapter_number = 3
#end
->chapter_3






