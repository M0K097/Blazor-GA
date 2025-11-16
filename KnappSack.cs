public class CItem
{
	public string name {get;set;}
	public int weight {get;set;}
	public int worth {get;set;}
	public bool picked {get;set;}

	public CItem(string name, int weight, int worth)
	{
		this.name = name;
		this.weight = weight;
		this.worth = worth;
		this.picked = false;
	}
}


