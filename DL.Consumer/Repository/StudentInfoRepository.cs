using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL.Consumer.Model;
using Microsoft.EntityFrameworkCore;

namespace DL.Consumer.Repository
{
    public class StudentInfoRepository : IStudentInfoRepository
    {
        private readonly ConsumerContext _context;

        public StudentInfoRepository(ConsumerContext context)
        {
          _context = context;
        }
        public async Task<List<StudentInfo>> GetAsync()
        {
            return await _context.StudentInfos.ToListAsync();
        }

        public async Task<StudentInfo> GetAsync(int id)
        {
            return await _context.StudentInfos.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<StudentInfo> Insert(StudentInfo studentInfo)
        {
            _context.Add(studentInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exp)
            {
            }

            return studentInfo;
        }

        public async Task<bool> UpdateAsync(StudentInfo studentInfo)
        {
            _context.StudentInfos.Attach(studentInfo);
            _context.Entry(studentInfo).State = EntityState.Modified;
            try
            {
               return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
          
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
          
            var customer = await _context.StudentInfos.SingleOrDefaultAsync(c => c.Id == id);
            _context.Remove(customer);
            try
            {
               return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
            }
            return false;
        }

  }
}
