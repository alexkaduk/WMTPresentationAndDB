using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WMTPresentation.Entities;

namespace WMTPresentation.Migrations
{
    [DbContext(typeof(PresentationDbContex))]
    [Migration("20160905062620_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("WMTPresentation.Entities.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChapterJson");

                    b.Property<int?>("LastAction");

                    b.Property<int>("Order");

                    b.Property<int>("PresentationId");

                    b.Property<string>("Title");

                    b.Property<string>("_id");

                    b.HasKey("Id");

                    b.HasIndex("PresentationId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("WMTPresentation.Entities.Presentation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DefaultFontSize");

                    b.Property<string>("PresentationJson");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Title");

                    b.Property<string>("_id");

                    b.HasKey("Id");

                    b.ToTable("Presentations");
                });

            modelBuilder.Entity("WMTPresentation.Entities.Slide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CDate");

                    b.Property<int>("ChapterId");

                    b.Property<bool>("Hidden");

                    b.Property<int>("Order");

                    b.Property<string>("SlideJson");

                    b.Property<string>("Title");

                    b.Property<string>("_id");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("WMTPresentation.Entities.Chapter", b =>
                {
                    b.HasOne("WMTPresentation.Entities.Presentation", "Presentation")
                        .WithMany("Chapters")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WMTPresentation.Entities.Slide", b =>
                {
                    b.HasOne("WMTPresentation.Entities.Chapter", "Chapter")
                        .WithMany("Slides")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
