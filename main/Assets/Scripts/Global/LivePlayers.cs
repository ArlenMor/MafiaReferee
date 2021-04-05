namespace Global
{
    //Класс для ведения учета оставшихся игроков в игре
    public static class LivePlayers
    {
        //массив живых и мертвых игроков
        private static bool[] s_Alive;
        //количество игроков в игре
        private static int s_NumberOfAlive;

        public static bool[] Alive => s_Alive;

        public static int NumberOfAlive => s_NumberOfAlive;

        //Инициализация всех игроков
        //Происходит во время запуска программы
        //Все оставшиеся игроки за столом имею значение 1
        //Все покинувшие игру игроки имею значение 0
        public static void Init()
        {
            s_Alive = new bool[10];

            for (int i = 0; i < 10; i++)
                s_Alive[i] = true;

            s_NumberOfAlive = 10;
        }
        
        public static void RemovePlayer(int index)
        {
            s_Alive[index] = false;

            s_NumberOfAlive--;
        }

        public static bool CheckAlivePlayer(int index)
        {
            if (s_Alive[index] == false)
                return false;
            return true;
        }
        
        
    }
}