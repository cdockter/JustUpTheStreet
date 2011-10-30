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
        return self.contributor.name
        
class Requirement(models.Model):
    id              = models.AutoField(primary_key=True)
    description     = models.TextField()
    
class Fulfillment(models.Model):
    id              = models.AutoField(primary_key=True)
    description     = models.TextField()
    rule            = models.ForeignKey(Requirement, verbose_name="requirement this fulfillment for")
    

class Prize(models.Model):
    id              = models.AutoField(primary_key=True)
    name            = models.CharField(max_length=256)
    description     = models.TextField()
    creator         = models.ForeignKey(Account, verbose_name="creator of the prize")
    contributions   = models.ManyToManyField(Contribution, verbose_name="contributions to this prize")
    rules           = models.ManyToManyField(Requirement, verbose_name="collection of requirement to claim the prize")
    
    STATE_CHOICES = (
        ('draft', 'Draft'),
        ('rfc', 'Request For Comment'),
        ('active', 'Active'),
        ('claim_w', 'Solution Window'),
        ('review_w', 'Review Window'),
        ('dispute_w', 'Dispute Window'),
        ('claimed', 'Solution Accepted'),
        ('disputed', 'Under Dispute'),
        ('expired', 'Expired'),
        ('paid', 'Completed'),
    )
    state = models.CharField(max_length=10, choices=STATE_CHOICES)
    
    def __unicode__(self):
        return self.name

class claim(models.Model):
  id          = models.AutoField(primary_key=True)
  claimer     = models.ForeignKey(Account, verbose_name="account that made the claim")
  claims      = models.ManyToManyField(Fulfillment, verbose_name="collection of assertions about how the requirements were ment")
  
  