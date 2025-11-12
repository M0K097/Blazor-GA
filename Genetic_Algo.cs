//a simple genetic algorithm in csharps blazor to run in browser

public class Genome
{
	Random dice = new Random();

	public string logos {get; set;}
	int dna_length {get;set;}
	List<char> genetic_material = new List<char>();

	public Genome(string solution_space, int dna_length)
	{
		logos = solution_space;
		this.dna_length = dna_length;
	}

	public void init()
	{
		genetic_material.Clear();
		for(int x = 0; x < dna_length; x++)
		{
			var picked = dice.Next(logos.Count() - 1);
			genetic_material.Add(logos[picked]);
		}
	}
}


class Population
{
	List<Genome> all_genomes = new List<Genome>();
	string logos {get;set;}
	int dna_length {get;set;}
	
	public void init(int number_of_individuals)
	{
		all_genomes.Clear();
		for (int x = 0; x < number_of_individuals ; x++)
		{
			Genome new_individual = new Genome(logos, dna_length);
			new_individual.init();
			all_genomes.Add(new_individual);
		}
	}

	Population(string solution_space, int dna_length)
	{
		logos = solution_space;
		this.dna_length = dna_length;
	}
	
}

class Utilities
{

}
