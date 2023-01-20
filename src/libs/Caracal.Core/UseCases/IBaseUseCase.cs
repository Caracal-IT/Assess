namespace Caracal.Core.UseCases; 

public interface IBaseUseCase<out TReturn, in TRequest> {
  TReturn Execute(TRequest request);
}