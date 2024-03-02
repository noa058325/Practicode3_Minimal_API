using Microsoft.EntityFrameworkCore;
namespace TodoApi;
 

class ToDoService
{
    private readonly ToDoDbContext _Db;

    public ToDoService(ToDoDbContext Db)
    {
        _Db = Db;
    }

    public  async Task<IEnumerable<Item>> Get(){
        return await _Db.Items.ToListAsync();
    }
    public  async Task<Item> Post(Item item){
        await _Db.Items.AddAsync(item);
            await _Db.SaveChangesAsync();
        return item;
    }
    
    public  async Task< Item> Put(int id, Item item){
            var i=await _Db.Items.FindAsync(id);
            if(i!=null){
                i.IsComplete=item.IsComplete;
                await _Db.SaveChangesAsync();
            }
        return item;
    }
    public  async Task<Item> Delete(int id){
            var item=await _Db.Items.FindAsync(id);
        if(item!=null)
        {
           _Db.Items.Remove(item);
            await _Db.SaveChangesAsync();
        }
        return item!;
    }
        
}


