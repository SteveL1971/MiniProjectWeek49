using Microsoft.EntityFrameworkCore;
using MiniProjectWeek49;
using System.Diagnostics;
using System.Linq;

MyDbContext context = new MyDbContext();

//Start of start code block. Creates a main menu which loops

bool menuLoop = true; // Boolean which monitors looping of main menu.
while (menuLoop)
{
    titleText(); // function to display top rows
    mainMenuText(); // function which displays the main menu text

    // switch case that handles main menu choices
    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine(" - Add an item\n");
            Thread.Sleep(200);
            addItem();
            break;
        case ConsoleKey.D2:
            Console.WriteLine(" - List items\n");
            Thread.Sleep(200);
            displayItems();
            break;
        case ConsoleKey.D3:
            Console.WriteLine(" - Edit/Delete items\n");
            Thread.Sleep(200);
            editItem();
            break;
        case ConsoleKey.D4:
            Console.WriteLine(" - Add an asset\n");
            Thread.Sleep(200);
            addAsset();
            break;
        case ConsoleKey.D5:
            Console.WriteLine(" - List assets\n");
            Thread.Sleep(200);
            displayAssets();
            break;
        case ConsoleKey.D6:
            Console.WriteLine(" - Quit application");
            menuLoop = false;
            Thread.Sleep(200);
            break;
        default:
            break;
    }
}

void titleText() // Function used to continually show the same title text regardless of which page user is on
{
    Console.Clear();
    Console.WriteLine("~ Asset tracking ~");
    Console.WriteLine("------------------");
}

void mainMenuText() // Funktion which creates and displays the main menu in the console
{
    Console.WriteLine("\nChoose from the following options:\n");
    Console.Write("(");
    colouredText("1","yellow");
    Console.WriteLine(") Add an item");
    Console.Write("(");
    colouredText("2", "yellow");
    Console.WriteLine(") List all items");
    Console.Write("(");
    colouredText("3", "yellow");
    Console.WriteLine(") Edit/Delete an item");
    Console.Write("(");
    colouredText("4", "yellow");
    Console.WriteLine(") Add an asset");
    Console.Write("(");
    colouredText("5", "yellow");
    Console.WriteLine(") List all assets");
    Console.Write("(");
    colouredText("6", "yellow");
    Console.WriteLine(") Quit Application\n");
}

void addAsset() // Adds an asset to assetList. Requires an Item, Office and a valid dateTime 
{
    // creates some variables to control looping because text gets updated once user has chosen an item and an office
    bool firstLoop = true;
    int selectedItem = -1;
    int selectedOffice = -1;
    bool allSelected = false;
    while (true)
    {
        if (selectedItem > -1 && selectedOffice > -1) allSelected = true;  // If true moves on to date selection at end of function 

        loopStart:

        titleText();
        Console.WriteLine("Add an asset\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("     " + "Type".PadRight(14) + " " + "Brand".PadRight(14) + " " + "Model".PadRight(14) + " " + "Price".ToString().PadRight(14));
        Console.ResetColor();

        Console.WriteLine("     " + "----".PadRight(14) + " " + "-----".PadRight(14) + " " + "-----".PadRight(14) + " " + "-----".PadRight(14));

        List<Item> unsortedList = context.Items.ToList();
        List<Item> sortedList = unsortedList.OrderBy(o => o.GetType().Name.ToString()).ThenBy(o => o.Brand).ToList(); // sorts items by Type and then by Brand

        //for loop to list all Items so user can choose
        for (var i = 0; i < sortedList.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(i.ToString().PadRight(5));
            Console.ResetColor();
            if (selectedItem == i)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sortedList[i].GetType().Name.ToString().PadRight(14) + " " + sortedList[i].Brand.PadRight(14) + " " + sortedList[i].Model.PadRight(14) + " $" + sortedList[i].Price.ToString().PadRight(14));
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(sortedList[i].GetType().Name.ToString().PadRight(14) + " " + sortedList[i].Brand.PadRight(14) + " " + sortedList[i].Model.PadRight(14) + " $" + sortedList[i].Price.ToString().PadRight(14));
            }
        }

        var value = -1; // intended to validate int input, but is redundant because int check failure changes this value to 0 regardless
        bool isInt = false;
        if (selectedItem == -1)
        {
            Console.WriteLine("\nSelect an item: ");
            string data = Console.ReadLine();
            Console.WriteLine("--------------------\n");
            isInt = int.TryParse(data, out value); // reflection: strange that a non-integer entry returns a 0
        }
        else
        {
            Console.WriteLine("\n--------------------\n");
            value = selectedItem;
            isInt = true;
        }

        // if item choice is successful move on to office choice

        if (isInt && value >= 0 && value < sortedList.Count) // needs to check value and isInt because Parse test returns 0 even if it is not a number
        {
            //display all Offices

            List<Office> offices = context.Offices.ToList();

            selectedItem = value;
            for (var i = 0; i < offices.Count; i++)
                {
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(i.ToString().PadRight(5));
                Console.ResetColor();
                if (selectedOffice == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(offices[i].Name.PadRight(14));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(offices[i].Name.PadRight(14));
                }
            }

            if (firstLoop == true)
            {
                firstLoop = false;
                goto loopStart;
            }

            if (!allSelected) // run if no office is chosen
            {
                Console.WriteLine("\nChoose an office");
                var data = Console.ReadLine();
                isInt = int.TryParse(data, out value);
                if (isInt && value >= 0 && value < offices.Count)
                {
                    selectedOffice = value;
                }
            }
            else // otherwise move forward to date selection
            {
                Console.WriteLine("\nPurchase date:\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("1".PadRight(5));
                Console.ResetColor();
                Console.WriteLine("Today's date");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("2".PadRight(5));
                Console.ResetColor();
                Console.WriteLine("Enter a different date");
                var data = Console.ReadLine();
                isInt = int.TryParse(data, out value);
                if (isInt && value >= 1 && value <= 2)
                {
                    Asset asset = new Asset();
                    switch (value) // handles menu choices. 
                    {
                        case 1: // make a date from today's date
                            asset.Item = sortedList[selectedItem];
                            asset.Office = offices[selectedOffice];
                            asset.PurchaseDate = DateTime.Now;
                            context.Assets.Add(asset);
                            context.SaveChanges();
                            
                            Console.WriteLine("\nAsset added!");
                            Thread.Sleep(1000);
                            break;
                        case 2: // make a date from user input. 
                            int day = 0;
                            int month = 0;
                            int year = 0;
                            Console.Write("Enter day dd: ".PadRight(14));
                            data = Console.ReadLine();
                            isInt = int.TryParse(data, out value);
                            if (isInt && value >= 1 && value <= 31) day = value;
                            Console.Write("Enter month MM: ".PadRight(14));
                            data = Console.ReadLine();
                            isInt = int.TryParse(data, out value);
                            if (isInt && value >= 1 && value <= 12) month = value;
                            Console.Write("Enter year YYYY: ".PadRight(14));
                            data = Console.ReadLine();
                            isInt = int.TryParse(data, out value);
                            if (value.ToString().Length == 4 && isInt && value >= 1970 && value <= 2099) year = value; // validates date and year is within an interval

                            try // tries to create a date 
                            {
                                DateTime dt = new DateTime(year, month, day);

                                asset.Item = sortedList[selectedItem];
                                asset.Office = offices[selectedOffice];
                                asset.PurchaseDate = dt;
                                context.Assets.Add(asset);
                                context.SaveChanges();

                                Console.WriteLine("\nAsset added!");
                                Thread.Sleep(1000);
                                break;
                            }
                            catch (Exception e)  // handles an invalid date by informing user and moving back to loopStart; 
                            {
                                colouredText("\nInvalid date!", "red");
                                Thread.Sleep(1000);
                                goto loopStart;
                            }
                    }
                    break;
                }
            }
        }
    }
}

void addItem() // function which allows a user to add an Item to itemList 
{
loopStart:
    titleText();
    Console.WriteLine("Select a Type:\n");
    Console.Write("(");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("1");
    Console.ResetColor();
    Console.WriteLine(") Mobile");
    Console.Write("(");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("2");
    Console.ResetColor();
    Console.WriteLine(") Laptop\n");
    var type = "";
    bool menuLoop = true;
    while (menuLoop)
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine(" - Mobile\n");
                type = "Mobile";
                Thread.Sleep(200);
                menuLoop = false;
                break;
            case ConsoleKey.D2:
                Console.WriteLine(" - Laptop\n");
                type = "Laptop";
                Thread.Sleep(200);
                menuLoop = false;
                break;
            default:
                break;
        }
    }
    Console.Write("Brand: ");
    string brand = Console.ReadLine();
    if (brand == "" || brand == null)
    {
        Console.WriteLine("\nInvalid entry - Brand can't be empty!\n");
        Thread.Sleep(1000);
        goto loopStart;
    }
    Console.Write("Model: ");
    string model = Console.ReadLine();
    if (model == "" || model == null)
    {
        Console.WriteLine("\nInvalid entry - Model can't be empty!\n");
        Thread.Sleep(1000);
        goto loopStart;
    }
    Console.Write("Price in USD: ");
    int price;
    string srtPrice = Console.ReadLine();
    bool isInt = int.TryParse(srtPrice, out price);
    if (!isInt)
    {
        Console.WriteLine("\nInvalid entry - Price must be an integer!\n");
        Thread.Sleep(1000);
        goto loopStart;
    }

    createItem(type, brand, model, price);
    Console.WriteLine("\nItem added!");
    Thread.Sleep(1000);
}

void createItem(string type, string brand, string model, int price) // Function that allows a user to create an Item and adds it to itemList as either a Mobile or a Laptop
{
    MyDbContext context = new MyDbContext();

    if (type == "Mobile")
    {
        Mobile mobile = new Mobile();

        mobile.Model = model;
        mobile.Brand = brand;
        mobile.Price = price;
        context.Mobiles.Add(mobile);
        context.SaveChanges();
    }
    else if (type == "Laptop")
    {
        Laptop laptop = new Laptop();

        laptop.Model = model;
        laptop.Brand = brand;
        laptop.Price = price;
        context.Laptops.Add(laptop);
        context.SaveChanges();
    }
}

void displayItems() // Fuction that loops through a sorted itemList to display all Items
{
    titleText();
    listItems();

    Console.WriteLine("\nPress any key to return to main menu");
    Console.ReadLine();
    Thread.Sleep(200);
}

void listItems()
{
    Console.WriteLine("\nAll items listed:\n");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    " + "Type".PadRight(14) + " " + "Brand".PadRight(14) + " " + "Model".PadRight(14) + " " + "Price".ToString().PadRight(14));
    Console.ResetColor();
    Console.WriteLine("    " + "----".PadRight(14) + " " + "-----".PadRight(14) + " " + "-----".PadRight(14) + " " + "-----".PadRight(14));

    List<Item> unsortedList = context.Items.ToList();
    List<Item> sortedList = unsortedList.OrderBy(o => o.GetType().Name.ToString()).ThenBy(o => o.Brand).ToList();

    for (int i = 0; i < sortedList.Count; i++)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write((i + 1).ToString().PadRight(4));
        Console.ResetColor();
        Console.WriteLine(sortedList[i].GetType().Name.ToString().PadRight(14) + " " + sortedList[i].Brand.PadRight(14) + " " + sortedList[i].Model.PadRight(14) + " $" + sortedList[i].Price.ToString().PadRight(14));

    }
}

void displayAssets() // Function that loops through a sorted assetList to display all Assets
{
    titleText();
    Console.WriteLine("\nAll assets listed:\n");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Type".PadRight(14) + " " + "Brand".PadRight(14) + " " + "Model".PadRight(14) + " " + "Office".PadRight(14) + " " + "Purchase Date".PadRight(14) + " " + "Price in USD".PadRight(14) + " " + "Currency".PadRight(10) + " " + "Local Price today".PadRight(17));
    Console.ResetColor();
    Console.WriteLine("----".PadRight(14) + " " + "-----".PadRight(14) + " " + "-----".PadRight(14) + " " + "------".PadRight(14) + " " + "-------------".PadRight(14) + " " + "------------".PadRight(14) + " " + "--------".PadRight(10) + " " + "-----------------".PadRight(17));

    List<Asset> unsortedList = context.Assets.ToList();
    List<Asset> sortedList = unsortedList.OrderBy(o => o.OfficeId).ThenBy(o => o.PurchaseDate).ToList();
    Office office = new Office();
    Item item = new Item();
    foreach (Asset asset in sortedList)
    {
        office = context.Offices.Include(x => x.Assets).FirstOrDefault(x => x.Id == asset.OfficeId);
        item = context.Items.Include(x => x.Assets).FirstOrDefault(x => x.Id == asset.ItemId);
        asset.printDetails(item, office);
    }
    Console.WriteLine("\nPress any key to return to main menu");
    Console.ReadLine();
    Thread.Sleep(200);
}

void colouredText(string text, string colour) // displays text with chosen colour
{
    switch (colour)
    {
        case "purple":
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            break;
        case "red":
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        case "green":
            Console.ForegroundColor = ConsoleColor.Green;
            break;
        case "blue":
            Console.ForegroundColor = ConsoleColor.Blue;
            break;
        case "yellow":
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }
    Console.Write(text);
    Console.ResetColor();
}

// handles editing and deleting a task
void editItem()
{
    while (true)
    {
        titleText();
        listItems();
        Console.WriteLine("\nChoose a task to edit or (q) to return to main menu: ");
        var data = Console.ReadLine();
        bool isInt = int.TryParse(data, out int listIndex);
        List<Item> unsortedList = context.Items.ToList();
        List<Item> sortedList = unsortedList.OrderBy(o => o.GetType().Name.ToString()).ThenBy(o => o.Brand).ToList();
        if (isInt && listIndex >= 1 && listIndex <= sortedList.Count)
        {
            Item item = sortedList[listIndex - 1];
            bool keepLooping = true;
            while (keepLooping == true)
            {
            loopStart:
                titleText();
                sortedList[listIndex - 1].printDetails(listIndex - 1);
                Console.Write("\n\nEdit task options:\n\n(");
                colouredText("1", "purple");
                Console.WriteLine(") Change brand");
                Console.Write("(");
                colouredText("2", "purple");
                Console.WriteLine(") Change model");
                Console.Write("(");
                colouredText("3", "purple");
                Console.WriteLine(") Change price");
                Console.Write("(");
                colouredText("4", "purple");
                Console.WriteLine(") Delete task");

                Console.WriteLine("\nChoose from menu (q) to return to previous page: ");
                int value = 0;
                data = Console.ReadLine();
                isInt = int.TryParse(data, out value);
                if (isInt && value >= 1 && value <= 4)
                {
                    switch (value)
                    {
                        case 1:
                            Console.WriteLine("\nEnter a new brand");
                            data = Console.ReadLine();
                            if (data != null && data.Length > 0)
                            {
                                Item itemToEdit = context.Items.FirstOrDefault(x => x.Id == Convert.ToInt32(listIndex - 1));
                                item.Brand = data;
                                context.Items.Update(itemToEdit);
                                context.SaveChanges();
                                colouredText("\nBrand changed to '" + data + "'", "green");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                colouredText("Brand can't be blank!", "red");
                                Thread.Sleep(1000);
                            }
                            break;
                        case 2:
                            Console.WriteLine("\nEnter a new model");
                            data = Console.ReadLine();
                            if (data != null && data.Length > 0)
                            {
                                Item itemToEdit = context.Items.FirstOrDefault(x => x.Id == Convert.ToInt32(listIndex - 1));
                                item.Model = data;
                                context.Items.Update(itemToEdit);
                                context.SaveChanges();
                                colouredText("\nModel changed to '" + data + "'", "green");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                colouredText("Model can't be blank!", "red");
                                Thread.Sleep(1000);
                            }
                            break; 
                        case 3:
                            Console.WriteLine("\nEnter a new price");
                            data = Console.ReadLine();
                            isInt = int.TryParse(data, out value);
                            if (data != null && data.Length > 0 && isInt)
                            {
                                Item itemToEdit = context.Items.FirstOrDefault(x => x.Id == Convert.ToInt32(listIndex - 1));
                                item.Price = value;
                                context.Items.Update(itemToEdit);
                                context.SaveChanges();
                                colouredText("\nPrice changed to '$" + data + "'", "green");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                colouredText("Price must be an integer!", "red");
                                Thread.Sleep(1000);
                            }
                            break;
                        case 4:
                            Console.Write("\nAre you sure you want to delete item '");
                            colouredText(item.Model, "blue");
                            Console.Write("'?");
                            Console.WriteLine("\n\nConfirm with (y) or any other key to return");
                            data = Console.ReadLine();
                            if (data.ToLower() == "y")
                            {
                                context.Items.Remove(item);
                                context.SaveChanges();
                                colouredText("\nThe item has been deleted!", "green");
                                Thread.Sleep(1000);
                            }
                            keepLooping = false;
                            break;
                    }
                }
                else
                {
                    if (data == "q") break;
                }
                if (keepLooping == false) break;
            }
        }
        else
        {
            if (data == "q") break;
        }
        Thread.Sleep(200);
    }
}



