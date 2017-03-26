using Bytes2you.Validation;
using CarManiacs.Business.Common;
using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Stories;
using CarManiacs.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManiacs.Business.Services
{
    public class StoryService : IStoryService
    {
        private IEfRepository<Story> storiesRepo;
        private IEfRepository<StoryStar> storyStarsRepo;

        public StoryService(
            IEfRepository<Story> storiesRepo,
            IEfRepository<StoryStar> storyStarsRepo)
        {
            Guard.WhenArgument(storiesRepo, "Story repository").IsNull().Throw();
            Guard.WhenArgument(storyStarsRepo, "StoryStar repository").IsNull().Throw();

            this.storyStarsRepo = storyStarsRepo;
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
                PublishDate = DateTime.Now,
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

        public int StarOrUnstar(Guid storyId, string userId)
        {
            Guard.WhenArgument(storyId, "storyId").IsEmptyGuid().Throw();
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var story = this.storiesRepo.GetById(storyId);
            if (story != null)
            {
                var storyStar = story.Stars.FirstOrDefault(s => s.UserId == userId);
                if (storyStar != null)
                {
                    story.Stars.Remove(storyStar);
                    this.storyStarsRepo.Delete(storyStar);
                    return story.Stars.Count;
                }
                else
                {
                    storyStar = new StoryStar() { Id = Guid.NewGuid(), StoryId = storyId, UserId = userId };
                    story.Stars.Add(storyStar);
                    return story.Stars.Count;
                }
            }

            return -1;
        }

        public bool HasUserStarred(Guid storyId, string userId)
        {
            Guard.WhenArgument(storyId, "storyId").IsEmptyGuid().Throw();
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var story = this.storiesRepo.GetById(storyId);
            if (story != null)
            {
                var storyStar = story.Stars.FirstOrDefault(s => s.UserId == userId);
                if (storyStar != null)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<Story> Get(int page, int numberOfProjects)
        {
            return storiesRepo.All
                .Where(s => s.IsDeleted == false)
                .OrderByDescending(s => s.PublishDate)
                .Skip(page * numberOfProjects)
                .Take(numberOfProjects)
                .ToList();
        }

        public IEnumerable<Story> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return null;
            }

            return storiesRepo.All
                .Where(s => s.IsDeleted == false &&
                    (s.Title.Contains(searchTerm) ||
                    (s.Content.Contains(searchTerm))))
                .OrderByDescending(s => s.PublishDate)
                .ToList();
        }

        public Story GetById(Guid storyId)
        {
            Guard.WhenArgument(storyId, "storyId").IsEmptyGuid().Throw();

            return this.storiesRepo.GetById(storyId);
        }

        public void Comment(Guid storyId, string userId, string comment)
        {
            Guard.WhenArgument(storyId, "storyId").IsEmptyGuid().Throw();
            Guard.WhenArgument(comment, "comment").IsNullOrEmpty().Throw();

            var story = this.storiesRepo.GetById(storyId);
            if (story != null)
            {
                story.Comments.Add(new StoryComment()
                {
                    Id = Guid.NewGuid(),
                    Content = comment,
                    PublishDate = DateTime.Now,
                    StoryId = storyId,
                    UserId = userId
                });
            }
        }
    }
}
