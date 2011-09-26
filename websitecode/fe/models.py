from django.db import models

# Create your models here.

class Account(models.Model):
    id      = models.AutoField(primary_key=True)
    name    = models.CharField(max_length=256)
    display = models.CharField(max_length=256)
    
    def __unicode__(self):
        return self.name

class Contribution(models.Model):
    id          = models.AutoField(primary_key=True)
    contributor = models.ForeignKey(Account, verbose_name="account that made the contribution")
    amount      = models.FloatField()
    created     = models.DateTimeField(auto_now_add=True)
    expires     = models.DateTimeField(auto_now=False)
    
    def __unicode__(self):
        return self.contributor.name + self.amount

class Prize(models.Model):
    id              = models.AutoField(primary_key=True)
    name            = models.CharField(max_length=256)
    description     = models.TextField()
    creator         = models.ForeignKey(Account, verbose_name="creator of the prize")
    contributions   = models.ManyToManyField(Contribution, verbose_name="contributions to this prize")
    
    STATE_CHOICES = (
        ('draft', 'Draft'),
        ('rfc', 'Request For Comment'),
        ('active', 'Active'),
        ('claimed', 'Solution Submitted'),
        ('disputed', 'Under dispute'),
        ('expired', 'Expired'),
        ('paid', 'Completed'),
    )
    state = models.CharField(max_length=10, choices=STATE_CHOICES)
    
    def __unicode__(self):
        return self.name
