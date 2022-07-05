using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmBlackWordRepository : IDmBlackWordRepository
    {
        private readonly MyDbContext _context;

        public DmBlackWordRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public DmBlackWord Add(DmBlackWordVM dmblackwordvm)
        {
            var _Blackwork = new DmBlackWord
            {
                Word = dmblackwordvm.Word,
                Ngaytao = DateTime.UtcNow,
                Ngaysua = DateTime.UtcNow
            };
            _context.Add(_Blackwork);
            _context.SaveChanges();
            return _Blackwork;
        }

        public List<DmBlackWord> GetAll()
        {
            var Blackworks = _context.dmBlackWords.Select(tb => tb);
            return Blackworks.ToList();
        }

        public bool Delete(string id)
        {
            var Blackwork = _context.dmBlackWords.SingleOrDefault(x=>x.Id.ToString()==id);
            if (Blackwork != null)
            {
                _context.Remove(Blackwork);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


       // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public DmBlackWord GetById(string id)
        {
            var Blackwork = _context.dmBlackWords.SingleOrDefault(cb => cb.Id.ToString() == id);
            return Blackwork;
        }

        public bool Update(DmBlackWord Blackword)
        {
            var _Blackword = _context.dmBlackWords.SingleOrDefault(w => w.Id == Blackword.Id);
            if (_Blackword != null)
            {
                _Blackword.Word = Blackword.Word;
                _Blackword.Ngaysua = Blackword.Ngaysua;
                _Blackword.Ngaytao = Blackword.Ngaytao;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
