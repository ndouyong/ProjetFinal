//Beging of the projet for the liberie system.

using ProjetFinal;
List<Livre> livres = new();

//Console.WriteLine(livres.Count);
bool x = true;
while(x)
{
    switch (Api.Menu())
    {
        //Option 1 pour ajouter un livre
        case 1 : {
            int id = livres.Count + 1;
            livres.Add(Api.Ajout_livre(id)); 
            break;
        } 

       
        
    }
}



