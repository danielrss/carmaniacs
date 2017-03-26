using CarManiacs.Business.Common;
using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Stories;
using CarManiacs.Business.Services.Contracts;

using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManiacs.Business.Services
{
    public class StoryService : IStoryService
    {
        private IEfRepository<Story> storiesRepo;

        public StoryService(IEfRepository<Story> storiesRepo)
        {
            Guard.WhenArgument(storiesRepo, "Story repository").IsNull().Throw();

            this.storiesRepo = storiesRepo;
        }

        public Guid Create(StoryDto newStory, string userId)
        {
            Guard.WhenArgument(newStory, "newStory").IsNull().Throw();
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var story = new Story()
            {
                Id = Guid.NewGuid(),
                Title = newStory.Title,
                Content = newStory.Content,
                MainImageUrl = Constants.DefaultStoryImageUrl,
                UserId = userId
            };

            this.storiesRepo.Add(story);
            return story.Id;
        }

        public void Update(StoryDto updatedStory)
        {
            Guard.WhenArgument(updatedStory, "updatedStory").IsNull().Throw();

            var story = this.storiesRepo.GetById(updatedStory.Id);
            if (story != null)
            {
                story.Title = updatedStory.Title;
                story.Content = updatedStory.Content;

                this.storiesRepo.Update(story);
            }
        }

        public void UpdateMainImageUrl(Guid storyId, string imageUrl)
        {
            Guard.WhenArgument(storyId, "storyId").IsEmptyGuid().Throw();

            var story = this.storiesRepo.GetById(storyId);
            if (story != null)
            {
                story.MainImageUrl = imageUrl;
                this.storiesRepo.Update(story);
            }
        }

        public IEnumerable<Story> GetAll()
        {
            return storiesRepo.All.ToList();
        }

        public Story GetById(Guid storyId)
        {
            Guard.WhenArgument(storyId, "storyId").IsEmptyGuid().Throw();

            return this.storiesRepo.GetById(storyId);
        }
    }
}
