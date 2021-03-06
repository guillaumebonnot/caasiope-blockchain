using System.Collections.Generic;
using Caasiope.Explorer.Database.Repositories;
using Caasiope.Explorer.Database.Repositories.Entities;
using Caasiope.Protocol.Types;

namespace Caasiope.Explorer.Transformers
{
    internal class HashLockTransformerService : ExplorerDataTransformerService<HashLockEntity, HashLockRepository>
    {
        protected override IEnumerable<HashLockEntity> Transform(DataTransformationContext context)
        {
            var hashlocks = context.SignedLedgerState.State.HashLocks;
            var list = new List<HashLockEntity>();
            var declarations = context.GetDeclarations();
            foreach (var locker in hashlocks)
            {
                list.Add(new HashLockEntity(GetDeclarationId(declarations.AddressDeclarations, locker.Address), new HashLockAccount(locker.Address, locker.SecretHash)));
            }
            return list;
        }

        private long GetDeclarationId(Dictionary<Address, TransactionDeclarationEntity> declarations, Address address)
        {
            return declarations[address].DeclarationId;
        }
    }
}