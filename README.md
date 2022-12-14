# EventBus

Три варианта создания event bus:

1) 	Common: Есть статический класс MessageHandler, в котором определены методы подписки/отписки и вызова события. Отправитель должен указать тип интерфейса и делегат, который вызовется у всех классов реализующий данный интерфейс (если они были подписаны в момент вызова). В данной реализации отписка у чистых классов происходит в методе Dispose.

2)	UniRX: В данном фрэймворке уже реализован свой MessageBroker, который может принимать в качестве обобщенного типа не только интерфейсы, но и обычные классы.

3) 	ECS: Реализация event bus в архитектуре ECS скорее больше философский вопрос. Мы имеем чёткую очередность выполнения систем, которая гарантирует, что при следующей итерации кадра все фильтры в системах выполнят свою логику. Если за событие взять какой-то компонент/реквест и очищать его по мере итерации, то будет гораздо легче отследить его путь, и очередность выполнения логики всех его подписчиков. Например есть система, которая отслеживает нажатие клавиши в кадре и создает событие/реквест о том, что клавиша нажата. Подписчиками в данном случае выступают две системы PlayerMoveSystem и TextUpdateSystem. Одна система двигает игрока, а другая обновляет текст на экране. При этом в следующем кадре перед отслеживанием нажатия новой клавиши вся предыдущая информация будет удалена функцией ClearInput. Разумеется, если отключить любую из систем не выполнится только та часть логики, за которую отвечает отключенная система. В данном подходе отписка от событий/реквестов не требуется.
