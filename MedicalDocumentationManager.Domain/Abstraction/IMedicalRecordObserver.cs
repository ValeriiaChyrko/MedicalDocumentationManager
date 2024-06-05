﻿namespace MedicalDocumentationManager.Domain.Abstraction;

public interface IMedicalRecordObserver : INotifiable
{
    void Subscribe();
    void Unsubscribe();

    bool IsRegistered(Delegate prospectiveHandler);
}