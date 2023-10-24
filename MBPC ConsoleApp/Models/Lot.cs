using MBPC_ConsoleApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MBPC_ConsoleApp.Models
{
    /// <summary>
    /// Op basis van teveilen_lijst pdf bestand
    /// 
    /// </summary>
    public class Lot
    {
        public int Id { get; set; }  // in voorbeelddata identiek aan LotId!!
        public Auction Auction { get; set; } // in DB auctionId -> op PDF Auction Number
        public Member VendorId { get; set; } // in DB venderId? -> op PDF Membership Number
        public Booklet Booklet { get; set; } // in DB bookletId -> ?? waar refereert dit veld naar op PDF?
        public int LotId { get; set; } // LOT No op Bied list formulier (nummer gegenereerd voor AuctionList) bij starten Auction kan dit niet meer worden aangepast
        public string MemberReference { get; set; } // Member ?? of wat betekende deze alweer? -> VendorId?
        public string description { get; set; } // Description of Lot op PDF
        public string PerfType { get; set; } // Perftype op PDF
        public string PerfCondition { get; set; } // Per condition op PDF
        public int Verified { get; set; } // ?? relatie PDF??
        public float ReservePrice { get; set; } // Reserve price op PDF

        /*
         * Mis DB/SB number en DP number?
         */

        public Lot()
        {

        }

        public Lot(int _id, string _memberRef, string _description)
        {
            Id = _id;
            MemberReference = _memberRef;
            description = _description;
        }

        public List<Lot> GetLotMembers(string _member)
        {
            iDAL sQLDal = DALSingleton.GetInstance();
            return sQLDal.ReadLotMember(_member);
        }
    }
}

