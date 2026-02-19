Учасники ballers:
  1) Рибаков Ігор
  2) Солопов Данило
```
```
Учасники 8-team:
  1) 
  2)
```
## Хто QA / хто Core
```
QA -
```
```
Core - Солопов Данило (wqep).
```
## Як заупстити тести
Iduno
## Як перевірити: List через enumerator, Sort default, Sort альтернативне, Stats
### Логіка:
1) Логіка **IEnumerable** знаходиться в класі відповідної колекції (Наприклад: `Lab1/Domain/Core/Enumerators`)

2) Логіка **IEnumerator** для всіх колекцій знаходиться у відповідній папці `Lab1/Domain/Core/Enumerators`.

3) Логіка **IComparer** для всіх колекцій знаходиться у відповідній папці `Lab1/Domain/Core/Comparers`.

4) Логіка **IComparable** знаходиться в відповідному класі об'єкту (Наприклад: `Lab1/Domain/Core/Enumerators`)

### Виконання:
> Перед тим як виконувати будь яку з нижче перерахованих дій потрібно створити відповідні об'єкти за допомгою меню.

**List через enumerator** - визивається через 13 пункт в меню:\
`13 - print with enumerator`\
\
**Sort default** - визивається через 14 пункт в меню:\
`14 - natural sort`\
\
**Sort альтернативне** - визивається через 15 пункт в меню:\
`15 - alternative sort`

### Сортування відбувається за наступними параметрами:
1) Ceck - `Id`
2) Event - `Name`
3) Ticket - `Price`
4) User - `Wallet.Balance`
5) Wallet - `Balance`