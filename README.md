# Lab02

# Створення файлів
Через присутній зв'язок багато до багатьох потребувалася проміжна таблиця (у моєму випадку BusRoute), яка була присутня, проте не створювалася у вигляді файлу XML. Списки записувалися у файли `routes.xml` та `buses.xml`, що ускладнювало та дублювало їх структуру. Дані записи були видалені та перенесені належним чином у файл `routesbuses.xml`

# Використання файлів
Відповідно зі змінами структур файлів були змінені запити, що зверталися, при потребі зв'язку багато до багатьох, до файлів `routes.xml` та/або `buses.xml`, на запити до допоміжного файлу `routebuses.xml`
