﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.Model.Request.OperationRequest;
using WebRecruitment.Application.Model.Response.OperationResponse;

using WebRecruitment.Domain.Entity;
using WebRecruitment.Application.IRepository.ApplyRepository;
using WebRecruitment.Infrastructure.GenericRepository;


namespace WebRecruitment.Infrastructure.Repository.ApplyRepository
{
    public class ApplyRepository : GenericRepository<Operation>, IApply
    {

        public ApplyRepository(TuyendungContext context) : base(context)
        {
        }

        public async Task CheckCvIdExistPost(Operation operation, Post post)
        {

            var operations = await _context.Set<Operation>()!.ToArrayAsync();

            var cvIDs = operations
                .Where(p => p.PostId == post.PostId)
                .Select(c => c.CvId)
                .ToList();

            if (cvIDs.Contains(operation.CvId))
            {
                throw new Exception("CV already submitted for this post");
            }


        }

     

        public async Task<List<Operation>> GetAllOperation()
        {
             var operation = await _context.Set<Operation>()!
                    .Include(c => c.Meetings)
                    .Include(c => c.Hr)
                    .Include(c => c.Company)
                    .Include(c => c.Cv)
                    .Include(c => c.Post)
                    .ThenInclude(c => c.Job)
                    .ToListAsync();
                return operation;
           
        }

        public async Task<Operation> GetByOperationId(Guid operationId)
        {

            var operation = await _context.Set<Operation>()!
                .Include(c => c.Meetings)
                .Include(c => c.Hr)
                .Include(c => c.Company)
                .Include(c => c.Cv)
                .Include(c => c.Post)
                .ThenInclude(c => c.Job)
                .FirstOrDefaultAsync(o => o.OperationId == operationId);
            if (operation == null)
            {
                throw new Exception("APPLY IS NULL");
            }
            return operation;

        }

       
    }
}
