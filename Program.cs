namespace rgb{
    class Program{
        class Pixel{
            public int red;
            public int green;
            public int blue;
            public Pixel(int r, int g, int b){
                red=r;green=g;blue=b;
            }
        }
        // 5. feladat
        static bool hatar(int sorszam, int elteres, Pixel[,] kep){
            
            int osszeg;
            for (int x = 1; x < 640; x++)
            {
                osszeg = Math.Abs(kep[sorszam,x-1].blue-kep[sorszam,x].blue);
                if(osszeg > elteres){

                Console.WriteLine($"{sorszam}. sor: ({kep[sorszam,x-1].blue}; {kep[sorszam,x].blue}) különbség: {osszeg}");
                }
                if(osszeg > elteres)return true;
            }
            return false;
        }
        public static void Main(string[] args){
            
            int width = 640;
            int height = 360;
            int[] szinek = new int[3];
            string[] t_sor;
            string[] beolvasas = File.ReadAllLines("kep-1.txt");
            Pixel[,] kep = new Pixel[height,width];
            

            
            int vilagos = 0; // 3. feladathoz

            int leg_s = 1000; // 4. feladathoz
            List<int[]> leg_s_rgb = new List<int[]>(); // 4. feladathoz

            for (int i = 0; i < height; i++)
            {
                t_sor = beolvasas[i].Split(' ');
                for (int j = 0; j < width*3; j+=3)
                {
                    szinek[0] = int.Parse(t_sor[j]);
                    szinek[1] = int.Parse(t_sor[j+1]);
                    szinek[2] = int.Parse(t_sor[j+2]);
                    kep[i,j/3] = new Pixel(szinek[0],szinek[1],szinek[2]);

                    if(szinek[0]+szinek[1]+szinek[2] > 600)vilagos++; // 3. feladathoz

                    // 4. feladathoz
                    if(szinek[0]+szinek[1]+szinek[2] <= leg_s){
                        leg_s = szinek[0]+szinek[1]+szinek[2];
                        leg_s_rgb.Add(new int[] {szinek[0],szinek[1],szinek[2]});
                        
                    }
                }
            }

            Console.WriteLine($"2. Feladat:\nKérem egy képpont adatait!");
            Console.Write($"Sor:");
            int sor = int.Parse(Console.ReadLine());
            Console.Write($"Oszlop:");
            int oszlop = int.Parse(Console.ReadLine());
            Console.WriteLine($"A képpont színe RGB({kep[sor,oszlop].red},{kep[sor,oszlop].green},{kep[sor,oszlop].blue})");
            Console.WriteLine($"3. Feladat:\nA világos képpontok száma: {vilagos}");
            Console.WriteLine($"4. Feladat:\nA legsötétebb pont RGB összege: {leg_s}");
            Console.WriteLine($"A legsötétebb pixelek színe:");
            foreach (var item in leg_s_rgb)
            {
                Console.WriteLine($"RGB({item[0]},{item[1]},{item[2]})");
            }
            //6. feladat
            int hatar_e = 10;
            int elso = 0;
            int utolso = 0;
            bool felho = false;
            
            for (int y = 0; y < height; y++)
            {
                if(!felho && hatar(y,hatar_e,kep)){
                    elso = y;
                    felho = true;
                    
                }
                if(felho && !hatar(y,hatar_e,kep)){
                    utolso = y-1;
                    break;
                }
            }
            Console.WriteLine($"6. feladat:");
            Console.WriteLine($"A felhő legfelső sora: {elso}");
            Console.WriteLine($"A felhő legalsó sora: {utolso}");
            Console.ReadKey();
        }
    }
}