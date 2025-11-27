
using Harjoitustyo;


Utils.ActionBreak("Press any key to start");

//create instance of all weapons
Weapon steelsword = new SteelSword();
GoldenSword goldensword = new GoldenSword();
Ass ass = new Ass();    //ass is shortened from ancient stone sword :p
Majesty majesty = new Majesty();

//create instance of all armors
Armor ironarmor = new Ironarmor();
Armor mithrilarmor = new MithrilArmor();
Armor dragonscalearmor = new DragonScaleArmor();
Armor gladguard = new GGuard();

//create instance of all enemies
AccursedMinion accursedMinion = new AccursedMinion();
Marblecolossus marblecolossus = new Marblecolossus();
TwilightArchmage twilightArchmage = new TwilightArchmage();
VoidEntity voidEntity = new VoidEntity();
CorruptedKing corruptedKing = new CorruptedKing();

//create instance of player
Player player = new Player(100, 50, steelsword, ironarmor);

//ask players name
Utils.SayLine("Your Name:", ConsoleColor.White);
player.Name = Console.ReadLine();
Console.Clear();

//small story and explanation for the player
Utils.SayLine("You wake up in a strange place called the Godlands. This land is known for its strong and lethal creatures.", ConsoleColor.DarkYellow);
Utils.ActionBreak("To escape this forsaken land you must defeat The Forgotten King.", ConsoleColor.DarkYellow);
Utils.SayLine("But to even get to him is a great challenge only meant for the greatest warriors", ConsoleColor.DarkYellow);
Console.WriteLine("You, " + player.Name + ", must prove yourself by defeating The Forgotten King\nThe Void Entity, Marble Colossus and Twilight Archmage");
Console.WriteLine("Good luck on your greatest challenge " + player.Name + "!");
Utils.ActionBreak("\nPress any key to continue", ConsoleColor.White);
MainMenu();

void MainMenu()
{
    while (true)
    {
        //ask player what he wants to do
        Utils.SayLine("What would you like to do " + player.Name + "?\n", ConsoleColor.White);

        Utils.SayLine("1. Battle the Marble Colossus", ConsoleColor.Gray);

        Utils.SayLine("2. Battle the Twilight Archmage", ConsoleColor.DarkMagenta);

        Utils.SayLine("3. Battle the Void Entity", ConsoleColor.DarkBlue);

        Utils.SayLine("4. Battle The Corrupted King", ConsoleColor.DarkYellow);

        Utils.SayLine("5. Kill Accursed Minions (Collect gold to prepare for bossfights)", ConsoleColor.DarkCyan);

        Utils.SayLine("6. Shop", ConsoleColor.Green);

        Utils.SayLine("7. Check Inventory", ConsoleColor.White);

        //Check what player choosed to do
        var playersAction = Console.ReadKey(true).KeyChar;

        //check what action player took
        if (playersAction == '1')
        {
            //player chose 1. Battle marble colossus
            Battle(marblecolossus);
        }
        else if (playersAction == '2')
        {
            //player chose 2. Battle Archmage
            Battle(twilightArchmage);
        }
        else if (playersAction == '3')
        {
            //player chose 3.
            Battle(voidEntity);
        }
        else if (playersAction == '4')
        {
            //pleyer chose 4.
            Battle(corruptedKing);
        }
        else if (playersAction == '5')
        {
            //player chose 5
            Battle(accursedMinion);
        }
        else if (playersAction == '6')
        {
            //player chose 6.
            Shop();
        }
        else if (playersAction == '7')
        {
            player.CheckInventory();
        }
        else
        {
            //if player presses any other button than the choices given tell him not choosable and back to menu
            Utils.ActionBreak("Can't choose that.");
        }
    }
}
void Battle(Enemy enemy)
{
    //some story before battle
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    //enemy says starting line
    enemy.Speak();


    //while loop for combat. loop ends when either player or enemy dies
    while (!enemy.IsDead && !player.IsDead)
    {
        //Show player and enemy hp
        Utils.Say($"{player.Name} current hp: {player.CurrentHp}/{player.MaxHp} ", ConsoleColor.Green);
        Utils.SayLine($"{enemy.Name} current hp: {enemy.CurrentHp}/{enemy.MaxHp}\n", ConsoleColor.Gray);

        //options during battle

        //attack
        Utils.SayLine($"1. Attack {enemy.Name}", ConsoleColor.DarkYellow);
        //potion up
        Utils.SayLine($"2. Use a potion", ConsoleColor.Green);
        //flee
        Utils.SayLine($"3. Try to retreat\n", ConsoleColor.DarkGray);
        //read option from player
        var playersAction = Console.ReadKey(true).KeyChar;

        switch (playersAction)
        {
            //player attacks enemy
            case '1':
                int damagetaken = enemy.GetsHit(player);

                //tells player how much dmg player did to enemy
                Utils.SayLine($"{player.Name} hits {enemy.Name} for {damagetaken} damage", ConsoleColor.DarkYellow);
                break;

            case '2':
                //use a potion
                break;

            case '3':
                //try to flee, if random number 5 or more player escapes 

                if (Player.PlayerRng() >= 5)
                {
                    Utils.ActionBreak("You managed escape.");
                    MainMenu();
                }
                else
                {
                    Utils.SayLine(enemy.EscapeLine, ConsoleColor.Red);
                }

                break;

            default:
                Utils.SayLine("Don't freeze now!", ConsoleColor.Red);
                break;
        }

        //if enemy is alive it attacks player        

        //attacks player
        int damage = player.GetsHit(enemy);

        //tells player how much dmg enemy did to player
        Utils.SayLine($"{enemy.Name} hits {player.Name} for {damage} damage\n", ConsoleColor.DarkRed);



    }
    if (enemy.IsDead)
    {
        //enemy last words after grave
        enemy.Speak();

        //tell player he has slain enemy and gained gold
        Utils.SayLine(enemy.Name + " has been slain", ConsoleColor.Green);
        Utils.Say("You gained ", ConsoleColor.DarkYellow);
        Utils.Say($"{enemy.Reward} gold", ConsoleColor.Yellow);
        Utils.ActionBreak("!");
        Console.Clear();
        MainMenu();
    }
    if(player.IsDead)
    {
        //player loses gold for being defeated half of the possible reward money from boss... unless player is at 0 gold then cant lose gold
        var goldLostOnDeath = enemy.Reward / 2;
        var goldLost = (player.GoldAmount - goldLostOnDeath);
        player.GoldAmount -= goldLost;

        //tell player he is dead and lost gold
        Utils.Say($"You died to {enemy.Name}", ConsoleColor.DarkRed);
        Utils.Say($" and lost", ConsoleColor.DarkRed);
        Utils.Say($" {goldLost} gold", ConsoleColor.Yellow);
        Utils.ActionBreak(".");
        Utils.Say("You have", ConsoleColor.DarkRed);
        Utils.Say($" {player.GoldAmount} gold ", ConsoleColor.Yellow);
        Utils.SayLine("left", ConsoleColor.DarkRed);
        Utils.SayLine("\npress any key to start again", ConsoleColor.White);
        Utils.ActionBreak("");
        player.Revive();
        MainMenu();
    }

}

void Shop()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Welcome to the Shop ===");
        Console.WriteLine("1. Buy Weapons");
        Console.WriteLine("2. Buy Armor");
        Console.WriteLine("9. Go Back");
        Console.Write("Choose an option: ");

        char choice = Console.ReadKey(true).KeyChar;

        switch (choice)
        {
            case '1':
                WeaponShop();
                break;

            case '2':
                ArmorShop();
                break;

            case '9':
                return; // go back
        }
    }
}

void WeaponShop()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Weapon Shop ===");
        Console.WriteLine("1. Steel Sword");
        Console.WriteLine("2. Golden Sword");
        Console.WriteLine("3. Ancient Stone Sword (ASS)");
        Console.WriteLine("4. Majesty");
        Console.WriteLine("9. Back");
        Console.Write("Choose a weapon: ");

        char choice = Console.ReadKey(true).KeyChar;

        switch (choice)
        {
            case '1':
                player.Inventory.AttemptPurchase(player, new SteelSword(), 50);
                break;

            case '2':
                player.Inventory.AttemptPurchase(player, new GoldenSword(), 150);
                break;

            case '3':
                player.Inventory.AttemptPurchase(player, new Ass(), 300);
                break;

            case '4':
                player.Inventory.AttemptPurchase(player, new Majesty(), 500);
                break;

            case '9':
                return; // back
        }
    }
}

void ArmorShop()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Armor Shop ===");
        Console.WriteLine("1. Iron Armor");
        Console.WriteLine("2. Mithril Armor");
        Console.WriteLine("3. Dragon Scale Armor");
        Console.WriteLine("4. Gladiator Guard");
        Console.WriteLine("9. Back");
        Console.Write("Choose an armor: ");

        char choice = Console.ReadKey(true).KeyChar;

        switch (choice)
        {
            case '1':
                player.Inventory.AttemptPurchase(player, new Ironarmor(), 40);
                break;

            case '2':
                player.Inventory.AttemptPurchase(player, new MithrilArmor(), 125);
                break;

            case '3':
                player.Inventory.AttemptPurchase(player, new DragonScaleArmor(), 350);
                break;

            case '4':
                player.Inventory.AttemptPurchase(player, new GGuard(), 200);
                break;

            case '9':
                return; // back
        }
    }
}

