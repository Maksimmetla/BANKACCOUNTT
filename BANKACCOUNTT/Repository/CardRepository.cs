using BANKACCOUNTT.Data;
using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.EntityFrameworkCore;

namespace BANKACCOUNTT.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly BankaccounttContext _context;
        public CardRepository(BankaccounttContext context)
        {
            _context = context;
        }
        public async Task<Card> CreateCardAsync(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return card;
        }
        public async Task<bool> DeleteCardAsync(int id)
        {
            var deletedEntry = await _context.Cards.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }
            _context.Cards.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Card>> GetAllAsync()
        {
            return await _context.Cards.ToListAsync();
        }
        public async Task<Card?> GetByIdAsync(int id)
        {
            return await _context.Cards.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<Card?> UpdateCardAsync(int id, Card card)
        {
            var ExitingCard = await _context.Cards.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (ExitingCard == null)
            {
                return null;
            }
            ExitingCard.Id = id;
            ExitingCard.User = card.User;
            ExitingCard.CardType = card.CardType;
            ExitingCard.Number = card.Number;
            ExitingCard.DateStart = card.DateStart;
            ExitingCard.DateEnd = card.DateEnd;
            ExitingCard.Cvv = card.Cvv;
            ExitingCard.Balance = card.Balance;
            ExitingCard.CardTypeId = card.CardTypeId;
            ExitingCard.UserId = card.UserId;
            ExitingCard.TransactionHistoryRecipientCards = card.TransactionHistoryRecipientCards;
            ExitingCard.TransactionHistorySendCards = card.TransactionHistorySendCards;
            await _context.SaveChangesAsync();
            return ExitingCard;
        }
    }
}
