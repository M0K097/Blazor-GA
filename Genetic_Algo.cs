//a simple genetic algorithm in csharps blazor to run in browser

public class Genome
{
	Random dice = new Random();

	public string logos {get; set;}
	int dna_length {get;set;}
	public List<char> genetic_material = new List<char>();

	public void init()
	{
		genetic_material.Clear();
		for(int x = 0; x < dna_length; x++)
		{
			var picked = dice.Next(logos.Count());
			genetic_material.Add(logos[picked]);
		}
	}

	public Genome(string solution_space, int dna_length)
	{
		logos = solution_space;
		this.dna_length = dna_length;
	}


}


public class Population
{
	public List<Genome> all_genomes = new List<Genome>();
	public string logos {get;set;}
	public int dna_length {get;set;}
	public int size {get;set;}
	
	public void init()
	{
		all_genomes.Clear();
		for (int x = 0; x < size ; x++)
		{
			Genome new_individual = new Genome(logos, dna_length);
			new_individual.init();
			all_genomes.Add(new_individual);
		}
	}

	public Population(string solution_space, int dna_length, int population_size)
	{
		logos = solution_space;
		this.dna_length = dna_length;
		size = population_size;
	}
	
}

