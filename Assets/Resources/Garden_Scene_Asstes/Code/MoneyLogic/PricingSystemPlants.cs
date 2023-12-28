 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class PricingSystemPlants : MonoBehaviour
{
   
    public class PlantPrices
    {
        //                                   0   1   2     3     4     5      6       7      8       9       10         11        12        13    14  14  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30  31  32  33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52  53  54 55 56    57
        public BigInteger[] objectPrice = { 15, 60, 240, 960, 3840, 15360, 61440, 245760, 983040, 3932160, 15728640, 62914560, 251658240, 1006632960, 4026531840, 16106127360, 64424509440, 257698037760, 1030792151040, 4123168604160, 16492674416640, 65970697666560, 263882790666240, 1055531162664960, 4222124650659840, 16888498602639360, 67553994410557440, 270215977642229760, 1080863910568919040, 4323455642275676160, 17293822569102704640, BigInteger.Parse("69175290276410818560"), BigInteger.Parse("276701161105643274240"), BigInteger.Parse("1106804644422573096960"), BigInteger.Parse("4427218577690292387840"), BigInteger.Parse("17708874310761169551360"), BigInteger.Parse("70835497243044678205440"), BigInteger.Parse("283341988972178712821760"), BigInteger.Parse("1133367955888714851287040"), BigInteger.Parse("4533471823554859405148160"), BigInteger.Parse("18133887294219437620592640"), BigInteger.Parse("72535549176877750482370560"), BigInteger.Parse("290142196707511001929482240"), BigInteger.Parse("1160568786830044007717928960"), BigInteger.Parse("4642275147320176030871715840"), BigInteger.Parse("18569100589280704123486863360"), BigInteger.Parse("74276402357122816493947453440"), BigInteger.Parse("297105609428491265975789813760"), BigInteger.Parse("1188422437713965063903159255040"), BigInteger.Parse("4753689750855860255612637020160"), BigInteger.Parse("19014759003423441022450548080640"), BigInteger.Parse("76059036013693764089802192322560"), BigInteger.Parse("304236144054775056359208769290240"), BigInteger.Parse("1216944576219100225436835077160960"), BigInteger.Parse("4867778304876400901747340308643840"), BigInteger.Parse("19471113219505603606989361234575360"), BigInteger.Parse("77884452878022414427957444938301440"), BigInteger.Parse("311537811512089657711829779753205760") };
        public BigInteger[] objectDestructionReturn = { 5, 15, 60, 240, 960, 3840, 15360, 61440, 245760, 983040, 3932160, 15728640, 62914560, 251658240, 1006632960, 4026531840, 16106127360, 64424509440, 257698037760, 1030792151040, 4123168604160, 16492674416640, 65970697666560, 263882790666240, 1055531162664960, 4222124650659840, 16888498602639360, 67553994410557440, 270215977642229760, 1080863910568919040, 4323455642275676160, 17293822569102704640, BigInteger.Parse("69175290276410818560"), BigInteger.Parse("276701161105643274240"), BigInteger.Parse("1106804644422573096960"), BigInteger.Parse("4427218577690292387840"), BigInteger.Parse("17708874310761169551360"), BigInteger.Parse("70835497243044678205440"), BigInteger.Parse("283341988972178712821760"), BigInteger.Parse("1133367955888714851287040"), BigInteger.Parse("4533471823554859405148160"), BigInteger.Parse("18133887294219437620592640"), BigInteger.Parse("72535549176877750482370560"), BigInteger.Parse("290142196707511001929482240"), BigInteger.Parse("1160568786830044007717928960"), BigInteger.Parse("4642275147320176030871715840"), BigInteger.Parse("18569100589280704123486863360"), BigInteger.Parse("74276402357122816493947453440"), BigInteger.Parse("297105609428491265975789813760"), BigInteger.Parse("1188422437713965063903159255040"), BigInteger.Parse("4753689750855860255612637020160"), BigInteger.Parse("19014759003423441022450548080640"), BigInteger.Parse("76059036013693764089802192322560"), BigInteger.Parse("304236144054775056359208769290240"), BigInteger.Parse("1216944576219100225436835077160960"), BigInteger.Parse("4867778304876400901747340308643840"), BigInteger.Parse("19471113219505603606989361234575360"), BigInteger.Parse("77884452878022414427957444938301440") };
        public BigInteger[] objectGrownIncome = { 1, 5, 12, 31, 78, 195, 488, 1220, 3051, 7629, 19073, 47683, 119209, 298023, 745058, 1862645, 4656612, 11641532, 29103830, 72759576, 181898940, 454747350, 1136868377, 2842170943, 7105427357, 17763568394, 44408920985, 111022302462, 277555756156, 693889390390, 1734723475976, 4336808689942, 10842021724855, 27105054312137, 67762635780344, 169406589450860, 423516473627150, 1058791184067875, 2646977960169688, 6617444900424220, 16543612251060550, 41359030627651376, 103397576569128448, 258493941422821120, 646234853557052800, 1615587133892632064, 4038967834731580416, 10097419586828951552, BigInteger.Parse("25243548967072378880"), BigInteger.Parse("63108872417680949248"), BigInteger.Parse("157772181044202373120"), BigInteger.Parse("394430452610505900032"), BigInteger.Parse("986076131526264750080"), BigInteger.Parse("2465190328815661875200"), BigInteger.Parse("6162975822039155212288"), BigInteger.Parse("15407439555097889079296"), BigInteger.Parse("38518598887744720601088"), BigInteger.Parse("96296497219361797308416") };
        public BigInteger[] objectUpgradeCost = { 20, 80, 320, 1280, 5120, 20480, 81920, 327680, 1310720, 5242880, 20971520, 83886080, 335544320, 1342177280, 5368709120, 21474836480, 85899345920, 343597383680, 1374389534720, 5497558138880, 21990232555520, 87960930222080, 351843720888320, 1407374883553280, 5629499534213120, 22517998136852480, 90071992547409920, 360287970189639680, 1441151880758558720, 5764607523034234880, BigInteger.Parse("23058430092136939520"), BigInteger.Parse("92233720368547758080"), BigInteger.Parse("368934881474191032320"), BigInteger.Parse("1475739525896764129280"), BigInteger.Parse("5902958103587056517120"), BigInteger.Parse("23611832414348226068480"), BigInteger.Parse("94447329657392904273920"), BigInteger.Parse("377789318629571617095680"), BigInteger.Parse("1511157274518286468382720"), BigInteger.Parse("6044629098073145873530880"), BigInteger.Parse("24178516392292583494123520"), BigInteger.Parse("96714065569170333976494080"), BigInteger.Parse("386856262276681335905976320"), BigInteger.Parse("1547425049106725343623905280"), BigInteger.Parse("6189700196426901374495621120"), BigInteger.Parse("24758800785707605497982484480"), BigInteger.Parse("99035203142830421991929937920"), BigInteger.Parse("396140812571321687967719751680"), BigInteger.Parse("1584563250285286751870879006720"), BigInteger.Parse("6338253001141147007483516026880"), BigInteger.Parse("25353012004564588029934064107520"), BigInteger.Parse("101412048018258352119736256430080"), BigInteger.Parse("405648192073033408478945025720320"), BigInteger.Parse("1622592768292133633915780102881280"), BigInteger.Parse("6490371073168534535663120411525120"), BigInteger.Parse("25961484292674138142652481646100480"), BigInteger.Parse("103845937170696552570609926584401920"), BigInteger.Parse("415383748682786210282439706337607680")};
        public BigInteger[] objectMenagerCost = { 150, 600, 2400, 9600, 38400, 153600, 614400, 2457600, 9830400, 39321600, 157286400, 629145600, 2516582400, 10066329600, 40265318400, 161061273600, 644245094400, 2576980377600, 10307921510400, 41231686041600, 164926744166400, 659706976665600, 2638827906662400, 10555311626649600, 42221246506598400, 168884986026393600, 675539944105574400, 2702159776422297600, 10808639105689190400, BigInteger.Parse("43234556422756761600"), BigInteger.Parse("1729382256910270464000"), BigInteger.Parse("691752902764108185600"), BigInteger.Parse("2767011611056432742400"), BigInteger.Parse("11068046444225730969600"), BigInteger.Parse("44272185776902923878400"), BigInteger.Parse("177088743107611695513600"), BigInteger.Parse("708354972430446782054400"), BigInteger.Parse("2833419889721787128217600"), BigInteger.Parse("11333679558887148512870400"), BigInteger.Parse("45334718235548594051481600"), BigInteger.Parse("181338872942194376205926400"), BigInteger.Parse("725355491768777504823705600"), BigInteger.Parse("2901421967075110019294822400"), BigInteger.Parse("11605687868300440077179289600"), BigInteger.Parse("46422751473201760308717158400"), BigInteger.Parse("185691005892807041234868633600"), BigInteger.Parse("742764023571228164939474534400"), BigInteger.Parse("2971056094284912659757898137600"), BigInteger.Parse("11884224377139650639031592550400"), BigInteger.Parse("47536897508558602556126370201600"), BigInteger.Parse("190147590034234410224505480806400"), BigInteger.Parse("760590360136937640898021923225600"), BigInteger.Parse("3042361440547750563592087692902400"), BigInteger.Parse("12169445762191002254368350771609600"), BigInteger.Parse("48677783048764009017473403086438400"), BigInteger.Parse("194711132195056036069893612345753600"), BigInteger.Parse("778844528780224144279574449383014400"), BigInteger.Parse("3115378115120896577118297797532057600") };
        public BigInteger[] objectMenagerUpgradeCost = { 200, 800, 3200, 12800, 51200, 204800, 819200, 3276800, 13107200, 52428800, 209715200, 838860800, 3355443200, 13421772800, 53687091200, 214748364800, 858993459200, 3435973836800, 13743895347200, 54975581388800, 219902325555200, 879609302220800, 3518437208883200, 14073748835532800, 56294995342131200, 225179981368524800, 900719925474099200, 3602879701896396800, 14411518807585587200, BigInteger.Parse("57646075230342348800"), BigInteger.Parse("230584300921369395200"), BigInteger.Parse("922337203685477580800"), BigInteger.Parse("3689348814741910323200"), BigInteger.Parse("14757395258967641292800"), BigInteger.Parse("59029581035870565171200"), BigInteger.Parse("236118324143482260684800"), BigInteger.Parse("944473296573929042739200"), BigInteger.Parse("3777893186295716170956800"), BigInteger.Parse("15111572745182864683827200"), BigInteger.Parse("60446290980731458735308800"), BigInteger.Parse("241785163922925834941235200"), BigInteger.Parse("967140655691703339764940800"), BigInteger.Parse("3868562622766813359059763200"), BigInteger.Parse("15474250491067253436239052800"), BigInteger.Parse("61897001964269013744956211200"), BigInteger.Parse("247588007857076054979824844800"), BigInteger.Parse("990352031428304219919299379200"), BigInteger.Parse("3961408125713216879677197516800"), BigInteger.Parse("15845632502852867518708790067200"), BigInteger.Parse("63382530011411470074835160268800"), BigInteger.Parse("253530120045645880299340641075200"), BigInteger.Parse("1014120480182583521197362564300800"), BigInteger.Parse("4056481920730334084789450257203200"), BigInteger.Parse("16225927682921336339157801028812800"), BigInteger.Parse("64903710731685345356631204115251200"), BigInteger.Parse("259614842926741381426524816461004800"), BigInteger.Parse("1038459371706965525706099265844019200"), BigInteger.Parse("4153837486827862102824397063376076800") };
        MoneyManager moneyManager;

        public PlantPrices() { }
        public PlantPrices(BigInteger[] objPrice, BigInteger[] objDestRet, BigInteger[] objInc, BigInteger[] objUpg, BigInteger[] mngCos, BigInteger[] mngUpg)
        {
            objectPrice = objPrice;
            objectDestructionReturn = objDestRet;
            objectGrownIncome = objInc;
            objectUpgradeCost = objUpg;
            objectMenagerCost = mngCos;
            objectMenagerUpgradeCost = mngUpg;
        }

        // Object price geter
        public BigInteger GetObjPrice(int id)
        {
            return objectPrice[id];
        }
        // Object destruction return geter
        public BigInteger GetObjDstructionReturn(int id)
        {
            return objectDestructionReturn[id];
        }
        // Object grown income geter
        public BigInteger GetObjGrownIncome(int id)
        {
            return objectGrownIncome[id];
        }
        // Object upgrade cost geter
        public BigInteger GetObjUpgradeCost(int id)
        {
            return objectUpgradeCost[id];
        }
        // Object menager income geter
        public BigInteger GetObjMenagerCost(int id)
        {
            return objectMenagerCost[id];
        }
        // Object menager upgrade cost
        public BigInteger GetObjMenagerUpgradeCost(int id)
        {
            return objectMenagerUpgradeCost[id];
        }

        //Changing money reward from fully grown plant
        public void UpdateIncomeValue(int objectId)
        {
            moneyManager = GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>();
            if (moneyManager.myBalance.moneyBalance >= objectUpgradeCost[objectId])
            {

                //Updating Profit from growing Plant
                BigInteger IncreaseUpdate, IncreaseIncome;
                IncreaseIncome = (objectPrice[objectId] / 8);
                objectGrownIncome[objectId] += IncreaseIncome;

                moneyManager.myBalance.DecrementBalance(objectUpgradeCost[objectId]);

                //Updating Cost of Upgrade
                IncreaseUpdate = ((objectUpgradeCost[objectId] / 3));
                objectUpgradeCost[objectId] += IncreaseUpdate;
            }
        }
        // Changing Price of upgrade for manager
        public void UpdateManagerCost(int objectId)
        {
            //updating price of manager after upgrade 
            BigInteger IncreaseUpdate;
            IncreaseUpdate = (objectMenagerUpgradeCost[objectId] / 2);
            objectMenagerUpgradeCost[objectId] += IncreaseUpdate;
        }
    }

    public PlantPrices plantPrices;

    public PricingSystemPlants()
    {
        plantPrices = new PlantPrices();
    }

    //Function to load saved prices
    public void LoadData(PlantPrices savedPrices)
    {
        plantPrices = savedPrices;
    }
}
