using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Helpers;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.ShiftData
{
    public class SqlShiftData : IShiftData
    {
        private PointOfSaleContext context;
        public SqlShiftData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Shift AddShift(ShiftDTO shift)
        {
            Shift _shift = new Shift();
            _shift.endTime = (DateTime)shift.endTime;
            _shift.startTime = (DateTime)shift.startTime;
            _shift.workdays = (int)shift.workdays;
            _shift.id = Guid.NewGuid();
            context.Shifts.Add(_shift);
            context.SaveChanges();
            return _shift;
        }

        public void DeleteShift(Guid id)
        {
            context.Shifts.Remove(GetShift(id));
            context.SaveChanges();
        }

        public Shift EditShift(Guid id, ShiftDTO shift)
        {
            var existing = context.Shifts.Find(id);
            existing.startTime = (DateTime)shift.startTime;
            existing.endTime = (DateTime)shift.endTime;
            existing.workdays = (int)shift.workdays;
            context.Shifts.Update(existing);
            context.SaveChanges();
            return existing;
        }

        public Shift PatchShift(Guid id, ShiftDTO customer)
        {
            var existing = context.Shifts.Find(id);
            if (existing != null)
            {
                existing = EntityHelper.PatchEntity<Shift>(existing, customer);
                context.Shifts.Update(existing);
                context.SaveChanges();
                return existing;
            }
            else
            {
                return null;
            }
        }

        public Shift GetShift(Guid id)
        {
            return context.Shifts.Find(id);
        }

        public List<Shift> GetShifts()
        {
            return context.Shifts.ToList();
        }
    }
}
