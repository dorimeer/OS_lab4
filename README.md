# Теоретический блок. Планирование 

Все задачи планирования и диспетчеризации, которые решаются на разных стадиях организации и управления вычислительным процессом, можно разделить на следующие категории: динамическое планирование; статическое планирование; балансовое планирование; планирования в реальном времени. 
Задача динамического планирования -  решение задачи распределения работ (составление расписания), готовых для выполнения в пространственных или пространственно-временных координатах при выполнении прикладных программ и на том же оборудовании. При динамическом планировании основным требованием к планировщикам, является минимизация времени решения самой задачи планирования, поскольку эти расходы являются непродуктивными затратами машинного времени и ресурсов, влияющие на эффективность использования. Указанное временное ограничение определяет принципы и алгоритмы работы динамических планировщиков.
В свою очередь, под статическим планированием понимают составление расписания загрузки процессоров однородной или неоднородной вычислительной системы взаимосвязанными работами, описываются ориентированным, ациклическим графом и решаемые к выполнению самого вычислительного процесса. При этом возможно их выполнение на другом оборудовании и в другое время. Статический планировщик имеет полную информацию о совокупности вычислительных работ, ресурсы, их взаимосвязь, взаимодействие, а также их количественные и качественные характеристики.

# Не исключающее планирование

Суть не исключающего планирования заключается в следующем. Надо найти такие назначения, без которых не обойтись - то есть те, которые претендуют на один единственный ресурс. Нужно найти в матрице такой строку, содержащую только одну единицу, по этой ячейке выполнить назначения, а матрицу редуцировать. Такое же предположение можно выдвинуть относительно ресурса - если ресурс претендует одна задача - это обязательно ее надо назначить на него. Это поиск единицы в столбце, после чего такое же назначение. 
Бывают такие случаи, когда матрицу нельзя редуцировать до конца - нет таких строк / столбцов, в которых только по одной единице - значит, в начале придется проводить назначение вручную случайным образом - особенно на результат оно не повлияет, после чего редуцировать матрицу дальше. В своей лабораторной работе я использую метод "первый подходящий".

# Результат выполнения

