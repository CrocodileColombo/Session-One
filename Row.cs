class Row
{
    int Id { get; set; }
    int Index { get; set; }
    string Region { get; set; }
    public Row(int id, int index, string region)
    {
        this.Id = id;
        this.Index = index;
        this.Region = region;

    }
    public string Print()
    {
        return ($"В {this.Region} индекс загрязнения {this.Index}");
    }
}
