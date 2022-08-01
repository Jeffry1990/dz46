using System;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomMinHelthPlayer = 450;
            int randomMaxHealthPlayer = 501;
            int playerHealth = random.Next(randomMinHelthPlayer, randomMaxHealthPlayer);
            int randomMinHelthBoss = 400;
            int randomMaxHealthBoss = 601;
            int bossHealth = random.Next(randomMinHelthBoss, randomMaxHealthBoss);
            int bossDamage;
            int shadowBallDamage = 50;
            int mindBlastDamage = 100;
            int soulFireDamage = 200;
            int restoringHealthPlayer = 300;
            bool isStartingFight = true;

            Console.WriteLine("Выберете заклинания для боя с боссом: \n 1) shadowball - Шар тьмы наносит 50 урона." +
                " \n 2) mindblast - Взрыв разума наносит 100 урона. \n 3) soulfire - Ожог души наносит 200 урона.(можно использовать если у босса больше здоровья чем у игрока) " +
                "\n 4) heal - Восстанавливает 300 здоровья. (можно использовать если у босса больше здоровья чем у игрока)");

            while (isStartingFight)
            {
                int randomMinDamageBoss = 100;
                int randomMaxDamageBoss = 151;
                bossDamage = random.Next(randomMinDamageBoss, randomMaxDamageBoss);
                Console.WriteLine("\nКоличество здоровья игрока - " + playerHealth);
                Console.WriteLine("Количество здоровья босса - " + bossHealth + ". Урон босса - " + bossDamage);
                Console.Write("Выберете заклинание: ");
                string userInputSpell = Console.ReadLine();
                
                if (playerHealth <= 0)
                {
                    isStartingFight = false;
                    Console.WriteLine("\nИгрок погиб");
                }
                else if (bossHealth <= 0)
                {
                    isStartingFight = false;
                    Console.WriteLine("\nИгрок победил");
                }
                else
                {   
                    switch(userInputSpell)
                    {
                        case "shadowball":
                            if(playerHealth > 0)
                            {
                                bossHealth -= shadowBallDamage;
                                Console.WriteLine("\nБосс потерял " + shadowBallDamage + " здоровья");
                                playerHealth -= bossDamage;
                                Console.WriteLine("\nПосле атаки босса игрок потерял " + bossDamage + " здоровья");
                            }
                            break;
                        case "mindblast":
                            if(playerHealth > 0)
                            {
                                bossHealth -= mindBlastDamage;
                                Console.WriteLine("\nБосс потерял " + mindBlastDamage + " здоровья");
                                playerHealth -= bossDamage;
                                Console.WriteLine("\nПосле атаки босса игрок потерял " + bossDamage + " здоровья");
                            }
                            break;
                        case "soulfire":
                            if(playerHealth < bossHealth)
                            {
                                bossHealth -= soulFireDamage;
                                Console.WriteLine("\nБосс потерял " + soulFireDamage + " здоровья");
                                playerHealth -= bossDamage;
                                Console.WriteLine("\nПосле атаки босса игрок потерял " + bossDamage + " здоровья");
                            }
                            else
                            {
                                Console.WriteLine("\nПока вы не можете использовать данное заклинание.");
                            }
                            break;
                        case "heal":
                            if(playerHealth < bossHealth)
                            {
                                playerHealth += restoringHealthPlayer;
                                Console.WriteLine("\nВы восстановили " + restoringHealthPlayer + " здоровья");
                                playerHealth -= bossDamage;
                                Console.WriteLine("\nПосле атаки босса игрок потерял " + bossDamage + " здоровья");
                            }
                            else
                            {
                                Console.WriteLine("\nПока вы не можете использовать данное заклинание.");
                            }
                            break;
                        default:
                            Console.WriteLine("\nНеизвестно это заклинание");
                            break;
                    }
                }
            }
        }
    }
}
