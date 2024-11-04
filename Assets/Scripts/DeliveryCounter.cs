public class DeliveryCounter : BaseCounter {

    public override void Interact(Player player) {
        if (player.HasKitchenObject()) {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                //plateKitchenObject.DestroySelf();
                player.GetKitchenObject().DestroySelf();
            }
        }
    }
}
